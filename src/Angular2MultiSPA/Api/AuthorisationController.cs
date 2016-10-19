﻿using Angular2MultiSPA.Models;
using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Server;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenIddict;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Angular2MultiSPA.Api
{
    public class AuthorisationController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private OpenIddictUserManager<ApplicationUser> _userManager;

        public AuthorisationController(OpenIddictUserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("~/connect/logout"), HttpPost("~/connect/logout")]
        public async Task  PostLogout()
        {
            var request = HttpContext.GetOpenIdConnectRequest();

            await _signInManager.SignOutAsync();
            SignOut(OpenIdConnectServerDefaults.AuthenticationScheme);
        }

        [AllowAnonymous]
        [HttpPost("~/connect/token")]
        public async Task<IActionResult> Exchange()
        {
            var request = HttpContext.GetOpenIdConnectRequest();

            if (request.IsPasswordGrantType())
            {
                var user = await _userManager.FindByNameAsync(request.Username);
                if (user == null)
                {
                    return Json(new OpenIdConnectResponse
                    {
                        Error = OpenIdConnectConstants.Errors.InvalidGrant
                    });
                }

                // Ensure the password is valid.
                if (!await _userManager.CheckPasswordAsync(user, request.Password))
                {
                    if (_userManager.SupportsUserLockout)
                    {
                        await _userManager.AccessFailedAsync(user);
                    }

                    return Json(new OpenIdConnectResponse
                    {
                        Error = OpenIdConnectConstants.Errors.InvalidGrant
                    });
                }

                if (_userManager.SupportsUserLockout)
                {
                    await _userManager.ResetAccessFailedCountAsync(user);
                }

                var identity = await _userManager.CreateIdentityAsync(user, request.GetScopes());

                // Create a new authentication ticket holding the user identity.
                var ticket = new AuthenticationTicket(
                    new ClaimsPrincipal(identity),
                    new AuthenticationProperties(),
                    OpenIdConnectServerDefaults.AuthenticationScheme);

                ticket.SetResources(request.GetResources());
                ticket.SetScopes(request.GetScopes());

                return SignIn(ticket.Principal, ticket.Properties, ticket.AuthenticationScheme);
            }

            return Json(new OpenIdConnectResponse
            {
                Error = OpenIdConnectConstants.Errors.UnsupportedGrantType
            });
        }
    }
}