using DotnetBoilerplate.Components.Api;
using DotnetBoilerplate.Components.Application;
using ExpensesManager.Application.Services;
using ExpensesManager.Application.Services.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ExpensesManager.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Expenses Manager API", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() 
                { 
                    Name = "Authorization", 
                    Type = SecuritySchemeType.ApiKey, 
                    Scheme = "Bearer", 
                    BearerFormat = "JWT", 
                    In = ParameterLocation.Header, 
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below. \r\n\r\nExample: \"Bearer 12345abcdef\"", 
                }); 

                c.AddSecurityRequirement(new OpenApiSecurityRequirement 
                { 
                    { 
                          new OpenApiSecurityScheme 
                          { 
                              Reference = new OpenApiReference 
                              { 
                                  Type = ReferenceType.SecurityScheme, 
                                  Id = "Bearer" 
                              } 
                          }, 
                         new string[] {} 
                    } 
                });  
            });            
            services.AddControllers();

            var secret = Configuration.GetSection("TokenSettings:Secret");
            var key = Encoding.ASCII.GetBytes(secret.Value);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });


            // Boilerplate Dependencies
            services.AddApi();
            services.AddApplication();

            services.AddScoped<ITokenServiceApplication, TokenServiceApplication>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API V1");
                c.RoutePrefix = "swagger";
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();
        }
    }
}
