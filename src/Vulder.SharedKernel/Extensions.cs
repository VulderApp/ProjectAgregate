using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Vulder.SharedKernel;

public static class Extensions
{
    public static void AddDefaultJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var authSection = configuration.GetSection("Jwt");
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSection.GetValue<string>("Key"))),
                    ValidateIssuer = true,
                    ValidIssuer = authSection.GetValue<string>("Issuer"),
                    ValidateAudience = true,
                    ValidAudience = authSection.GetValue<string>("Audience"),
                    RequireExpirationTime = true,
                    ValidateLifetime = true
                };
            });
    }

    public static void AddDefaultCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CORS", corsPolicyBuilder =>
            {
                corsPolicyBuilder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }
}