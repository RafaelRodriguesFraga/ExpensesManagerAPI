using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DotnetBaseKit.Components.Application.Base;
using DotnetBaseKit.Components.Shared.Notifications;
using expensesManager.Application.Services;
using ExpensesManager.Application.ViewModels.User;
using ExpensesManager.Shared.Localization;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;

namespace ExpensesManager.Application.Services.Token
{
    public class TokenServiceApplication : BaseServiceApplication, ITokenServiceApplication
    {
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache _cache;
        private readonly IStringLocalizer _localizer;


        public TokenServiceApplication(NotificationContext notificationContext, IConfiguration configuration, 
            IDistributedCache cache,
            IStringLocalizerFactory localizerFactory) : base(notificationContext)
        {
            _configuration = configuration;
            _cache = cache;

            var assembly = typeof(Messages).Assembly;
            _localizer = localizerFactory.Create("Localization.Messages", assembly.GetName().Name);
        }       

        public TokenViewModel GenerateTokenAsync(UserViewModel userViewModel)
        {
            var secret = _configuration.GetSection("TokenSettings:Secret").Value;
            var expiresToken = _configuration.GetSection("TokenSettings:ExpiresToken").Value;

            if (string.IsNullOrEmpty(secret) || string.IsNullOrEmpty(expiresToken))
            {
                throw new Exception(_localizer["SecretOrExpiresTokenNotFound"]);
            }

            var date = DateTime.Now;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                NotBefore = date,
                IssuedAt = date,
                Expires = date.AddHours(Convert.ToInt32(expiresToken) | 2),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, userViewModel.Email),
                    new Claim(ClaimTypes.NameIdentifier, userViewModel.Id.ToString()),

                }),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var createToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(createToken);
            var refreshToken = GenerateRefreshToken();
            SaveRefreshToken(userViewModel.Email, refreshToken);
            
            TokenViewModel tokenViewModel = new TokenViewModel
            { 
                Id = userViewModel.Id,
                Email = userViewModel.Email,
                Token = token,
                RefreshToken = refreshToken,
                ExpirationDate = tokenDescriptor.Expires.Value,
                IssuedAt = tokenDescriptor.IssuedAt.Value,
            };

            return tokenViewModel;
        }

        public string GenerateToken(IEnumerable<Claim> claims)
        {
            var secret = _configuration.GetSection("TokenSettings:Secret").Value;
            var expiresToken = _configuration.GetSection("TokenSettings:ExpiresToken").Value;

            if (string.IsNullOrEmpty(secret) || string.IsNullOrEmpty(expiresToken))
            {
                throw new Exception(_localizer["SecretOrExpiresTokenNotFound"]);
            }

            var date = DateTime.Now;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                NotBefore = date,
                IssuedAt = date,
                Expires = date.AddHours(Convert.ToInt32(expiresToken) | 2),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var createToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(createToken);

            return token;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var secret = _configuration.GetSection("TokenSettings:Secret").Value;
            var key = Encoding.ASCII.GetBytes(secret);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = false            
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException(_localizer["InvalidToken"]);
            }


            return principal;

        }               

        public void SaveRefreshToken(string username, string refreshToken)
        {
            try
            {
                _cache.SetString($"refreshToken:{username}", refreshToken);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public string GetRefreshToken(string username)
        {

            var refreshToken = _cache.GetString($"refreshToken:{username}");

            return refreshToken;
        }

        public void DeleteRefreshToken(string username, string refreshToken)
        {
            _cache.Remove($"refreshToken:{username}");
        }
    }
}