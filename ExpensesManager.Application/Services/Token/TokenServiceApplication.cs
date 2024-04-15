using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using DotnetBaseKit.Components.Application.Base;
using DotnetBaseKit.Components.Shared.Notifications;
using expensesManager.Application.Services;
using ExpensesManager.Application.ViewModels.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ExpensesManager.Application.Services.Token
{
    public class TokenServiceApplication : BaseServiceApplication, ITokenServiceApplication
    {
        private readonly IConfiguration _configuration;

        public TokenServiceApplication(NotificationContext notificationContext, IConfiguration configuration) : base(notificationContext)
        {
            _configuration = configuration;
        }

        public TokenViewModel GenerateTokenAsync(UserViewModel userViewModel)
        {
            var secret = _configuration.GetSection("TokenSettings:Secret").Value;
            var expiresToken = _configuration.GetSection("TokenSettings:ExpiresToken").Value;

            if (string.IsNullOrEmpty(secret) || string.IsNullOrEmpty(expiresToken))
            {
                throw new Exception("Secret or ExpiresToken not found in appsettings.json");
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
                    new Claim(JwtRegisteredClaimNames.Jti, userViewModel.Id.ToString()),

                }),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var createToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(createToken);

            TokenViewModel tokenViewModel = new TokenViewModel
            {
                Id = userViewModel.Id,
                Email = userViewModel.Email,
                Token = token,
                ExpirationDate = tokenDescriptor.Expires.Value,
                IssuedAt = tokenDescriptor.IssuedAt.Value,
            };

            return tokenViewModel;
        }
    }
}