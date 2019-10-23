using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TechTalks.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddAuthorization();

            services.AddCors(
                options => options.AddPolicy("AllowCors",
                builder =>
                {
                    builder
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                })
            );

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.Authority = "https://localhost:44388/";
                   options.Audience = "talks";
               });

            var guestPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .RequireClaim("scope", "talks")
                .Build();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("talksAdmin", policyAdmin =>
                {
                    policyAdmin.RequireClaim("role", "talks.admin");
                });
                options.AddPolicy("talksUser", policyUser =>
                {
                    policyUser.RequireClaim("role", "talks.user");
                });
                options.AddPolicy("talks", policyUser =>
                {
                    policyUser.RequireClaim("scope", "talks");
                });
            });

            services.AddControllers()
               .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowCors");

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
