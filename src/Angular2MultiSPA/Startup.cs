using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Angular2MultiSPA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using CryptoHelper;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NWebsec.AspNetCore.Middleware;
using OpenIddict;
using Angular2MultiSPA.Models;
using Angular2MultiSPA.Services;
using System.Threading.Tasks;
using AspNet.Security.OpenIdConnect.Server;
using Microsoft.AspNetCore.Identity;
using AspNet.Security.OpenIdConnect.Extensions;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Authentication;

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
            // note also: https://github.com/openiddict/openiddict-core/pull/203
            // very useful: http://viters.net/blog/post/uwierzytelniania-ciag-dalszy-rozmowa-angulara-2-z-asp-net-core-przy-uzyciu-tokenow-jwt/
            // translated: http://www.microsofttranslator.com/bv.aspx?ref=SERP&br=ro&mkt=en-AU&dl=en&lp=PL_EN&a=http%3a%2f%2fviters.net%2fblog%2fpost%2fuwierzytelniania-ciag-dalszy-rozmowa-angulara-2-z-asp-net-core-przy-uzyciu-tokenow-jwt%2f

            // Register the Identity services.
            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                .AddEntityFrameworkStores<ApplicationDbContext, Guid>()
                .AddDefaultTokenProviders();

            // add service lifetime for seeder class
            services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);

            // Register the OpenIddict services, including the default Entity Framework stores.
            services.AddOpenIddict<ApplicationUser, IdentityRole<Guid>, ApplicationDbContext, Guid>()

                // Enable the authorization, logout, token and userinfo endpoints.
                //.EnableAuthorizationEndpoint("/connect/authorize")
                //.EnableLogoutEndpoint("/connect/logout")
                .EnableTokenEndpoint("/connect/token")
                //.EnableUserinfoEndpoint("/connect/userinfo")
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


            //app.UseJwtBearerAuthentication(new JwtBearerOptions
            //{
            //    Authority = "http://localhost:7010",
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true,
            //    Audience = "http://localhost:7010",
            //    RequireHttpsMetadata = false
            //});

            // Alternatively, you can also use the introspection middleware.
            // Using it is recommended if your resource server is in a different application/separated from the authorization server.
            // 
            // app.UseOAuthIntrospection(options => {
            //     options.AutomaticAuthenticate = true;
            //     options.AutomaticChallenge = true;
            //     options.Authority = "http://localhost:54540/";
            //     options.Audience = "resource_server";
            //     options.ClientId = "resource_server";
            //     options.ClientSecret = "875sqd4s5d748z78z7ds1ff8zz8814ff88ed8ea4z4zzd";
            // });


            using (var context = new ApplicationDbContext(
                app.ApplicationServices.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                context.Database.EnsureCreated();
            };

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                routes.MapWebApiRoute("defaultApi", "api/{controller}/{id?}");
                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "home", action = "index" });
            });
        }
    }
}
