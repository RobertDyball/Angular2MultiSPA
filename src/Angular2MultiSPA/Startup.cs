using Angular2MultiSPA.Data;
using Angular2MultiSPA.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Angular2MultiSPA
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                //.AddJsonFile("hosting.json", optional: true)
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NorthwindContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("NorthwindConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("ApplicationDbConnection")));

            // follow the OpenIdDict guide here: https://github.com/openiddict/openiddict-core
            // also: https://github.com/openiddict/openiddict-core/pull/203
            // very useful: http://viters.net/blog/post/uwierzytelniania-ciag-dalszy-rozmowa-angulara-2-z-asp-net-core-przy-uzyciu-tokenow-jwt/

            // Register the Identity services.
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationDbContext, Guid>()
                .AddDefaultTokenProviders();

            // add service lifetime for seeder class
            services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);

            // Register the OpenIddict services, including the default Entity Framework stores.
            services.AddOpenIddict<ApplicationUser, IdentityRole<Guid>, ApplicationDbContext, Guid>()

                // Enable the authorization, logout, token and userinfo endpoints.
                .EnableAuthorizationEndpoint("/connect/authorize")
                .EnableLogoutEndpoint("/connect/logout")
                .EnableTokenEndpoint("/connect/token")
                .EnableUserinfoEndpoint("/connect/userinfo")
                .UseJsonWebTokens()

                // Allow client applications to use the grant_type=password flow.
                .AllowPasswordFlow() 
                .AllowRefreshTokenFlow()

                // During development, you can disable the HTTPS requirement.
                .DisableHttpsRequirement()

                // Register a new ephemeral key, that is discarded when the application shuts down. Tokens signed using 
                // this key are automatically invalidated. This method should only be used during development.
                .AddEphemeralSigningKey();

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IServiceScopeFactory scopeFactory)
        {
            // logging: http://docs.asp.net/en/latest/fundamentals/logging.html 
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();

                //using (var context = new ApplicationDbContext(app.ApplicationServices.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
                //{
                //    context.Database.EnsureCreated();
                //}

                //scopeFactory.SeedData();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),
                RequestPath = "/node_modules"
            });

            app.UseIdentity();

            // Add a middleware used to validate access tokens and protect the API endpoints.
            app.UseOAuthValidation();

            app.UseOpenIddict();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routes.MapWebApiRoute("defaultApi", "api/{controller}/{id?}");
                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "home", action = "index" });
            });
        }
    }
}
