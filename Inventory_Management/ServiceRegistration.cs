using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InventoryManagement.Service;
//using InventoryManagement.Security;
//using InventoryManagement.Security.Models;

namespace InventoryManagement
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddApiRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddAutoMapper(typeof(Api.AutoMapperProfile).Assembly);
            services.AddService(configuration);
            //services.AddValidatorsFromAssemblyContaining<UserValidator>();
            //services.AddFluentValidationAutoValidation();
            //services.AddSecurity(configuration);
            services.AddAuthentication(configuration);
            return services;
        }

        private static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {

            //var jwtAppSettingOptions = configuration.GetSection(nameof(JwtIssuerOptions));
            //SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtAppSettingOptions[nameof(JwtIssuerOptions.SecretKey)]));
            //services.Configure<JwtIssuerOptions>(options =>
            //{
            //    options.ValidFor = TimeSpan.Parse(jwtAppSettingOptions[nameof(JwtIssuerOptions.ValidFor)]);
            //    options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
            //    options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
            //    options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            //});

            //services.Configure<EmailTemplateSettings>(options => configuration.GetSection(nameof(EmailTemplateSettings)).Bind(options));
            //services.Configure<AWSSettings>(options => configuration.GetSection("AWS").Bind(options));
            //services.Configure<DomainUrl>(options => configuration.GetSection(nameof(DomainUrl)).Bind(options));
            //services.Configure<AccessToken>(options => configuration.GetSection(nameof(AccessToken)).Bind(options));

            //var tokenValidationParameters = new TokenValidationParameters
            //{
            //    ValidateIssuer = true,
            //    ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],
            //    ValidateAudience = true,
            //    ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],
            //    ValidateLifetime = true,
            //    ValidateIssuerSigningKey = true,
            //    RequireExpirationTime = false,
            //    ClockSkew = TimeSpan.Zero,
            //    IssuerSigningKey = _signingKey
            //};
            //services.AddSingleton(tokenValidationParameters);

            //services.AddAuthentication(auth =>
            //{
            //    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //})
            //.AddJwtBearer(option =>
            //{
            //    option.TokenValidationParameters = tokenValidationParameters;
            //    option.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
            //    option.SaveToken = true;
            //});
        }

    }
}







