using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TemperatureSensor.Infrastructure.WebApi
{
    public class WebApi
    {
        public static void ConfigureServices(IServiceCollection services, string issuer, string audience, string secretForKey)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretForKey))
                    };
                });
        }
    }
}
