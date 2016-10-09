using CryptoHelper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OpenIddict;
using System;
using System.Linq;

namespace Angular2MultiSPA.Models
{
    public static class ApplicationDbContextSeedData
    {
        public static async void SeedData(this IServiceScopeFactory scopeFactory)
        {
            ApplicationDbContext context;
            UserManager<ApplicationUser> userManager;
            //RoleManager<ApplicationRole> roleManager;

            using (var serviceScope = scopeFactory.CreateScope())
            {
                context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                userManager = serviceScope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                //roleManager = serviceScope.ServiceProvider.GetService<RoleManager<ApplicationRole>>();

                await context.Database.EnsureCreatedAsync();

                // Add Mvc.Client to the known applications.
                //if (context.Applications.Any())
                //{
                //    foreach (var application in context.Applications)
                //        context.Remove(application);
                //    context.SaveChanges();
                //}

                //if (!context.Applications.Any())
                //{
                //    context.Applications.Add(new OpenIddictApplication<Guid>
                //    {
                //        Id = Guid.NewGuid(),
                //        ClientId = "angular2MultiSPI",
                //        DisplayName = "Angular 2 Multi SPA",
                //        RedirectUri = "http://localhost:7010/about",
                //        LogoutRedirectUri = "http://localhost:7010/home",
                //        ClientSecret = Crypto.HashPassword("secret_secret_secret"),
                //        Type = OpenIddictConstants.ClientTypes.Public
                //    });
                //}

                if (context.Users.Any())
                {
                    foreach (var u in context.Users)
                        context.Remove(u);
                    context.SaveChanges();
                }


                if (!context.Users.Any())
                {
                    var email = "user@test.com";
                    ApplicationUser user;
                    if (await userManager.FindByEmailAsync(email) == null)
                    {
                        // use the create rather than addorupdate so can set password
                        user = new ApplicationUser
                        {
                            UserName = email,
                            Email = email,
                            EmailConfirmed = true,
                            GivenName = "Sean"
                        };
                        await userManager.CreateAsync(user, "P2ssw0rd!");
                    }

                    user = await userManager.FindByEmailAsync(email);
                    //var roleName = "testrole";
                    //if (await roleManager.FindByNameAsync(roleName) == null)
                    //{
                    //    await roleManager.CreateAsync(new ApplicationRole() { Name = roleName });
                    //}

                    //if (!await userManager.IsInRoleAsync(user, roleName))
                    //{
                    //    await userManager.AddToRoleAsync(user, roleName);
                    //}

                    context.AddRange(user);
                    context.SaveChanges();
                }
            }
        }
    }
}