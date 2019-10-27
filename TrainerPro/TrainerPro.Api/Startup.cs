namespace TrainerPro.Api
{
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.OpenApi.Models;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    using TrainerPro.Api.Helpers.Models;
    using TrainerPro.Core.Identities;
    using TrainerPro.DAL;
    using TrainerPro.Services.Interfaces;
    using TrainerPro.Services.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddRazorPages();

            // Configure DbContext and Identity
            services.AddDbContext<TrainerProContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TrainerPro")));
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>().AddEntityFrameworkStores<TrainerProContext>();

            // Configure JWT Settings and register it
            var jwtSettingsConfiguration = Configuration.GetSection("JwtSettings");
            var jwtSettings = jwtSettingsConfiguration.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.SecretKey);
            services.AddSingleton(jwtSettings);

            // Configure JWT Authentication
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience
                };
            });

            // Configure Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Trainer-Pro API",
                    Description = "Test Trainer-Pro API with ASP.NET Core 3.0",
                    Contact = new OpenApiContact
                    {
                        Email = "davejab97@gmail.com",
                    },
                    License = new OpenApiLicense
                    {
                        Name = "No license here :)",
                    }
                });

            });

            // Configure Services
            var emailSettings = Configuration.GetSection("EmailSettings").Get<EmailSettings>();
            services.AddScoped<IEmailSender, EmailSender>(sp => new EmailSender(emailSettings.Host, emailSettings.Port, emailSettings.EnableSSL, emailSettings.Username, emailSettings.Password));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IViewRenderService, ViewRenderService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trainer-Pro API V1");
            });
        }
    }
}
