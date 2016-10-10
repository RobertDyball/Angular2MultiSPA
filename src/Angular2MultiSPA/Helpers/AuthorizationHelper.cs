using Angular2MultiSPA.Models;
using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Server;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Angular2MultiSPA.Helpers
{
    public class AuthorizationHelper
    {
        //public override Task ValidateTokenRequest(ValidateTokenRequestContext context)
        //{
        //    // Reject the token requests that don't use grant_type=password or grant_type=refresh_token.
        //    if (!context.Request.IsPasswordGrantType() && !context.Request.IsRefreshTokenGrantType())
        //    {
        //        context.Reject(
        //            error: OpenIdConnectConstants.Errors.UnsupportedGrantType,
        //            description: "Only the resource owner password credentials and refresh token " +
        //                         "grants are accepted by this authorization server");

        //        return Task.FromResult(0);
        //    }

        //    // Since there's only one application and since it's a public client
        //    // (i.e a client that cannot keep its credentials private), call Skip()
        //    // to inform the server the request should be accepted without 
        //    // enforcing client authentication.
        //    context.Skip();

        //    return Task.FromResult(0);
        //}


        //public override Task ValidateTokenRequest(ValidateTokenRequestContext context)
        //{
        //    // Reject the token request that don't use grant_type=password or grant_type=refresh_token.
        //    if (!context.Request.IsPasswordGrantType() && !context.Request.IsRefreshTokenGrantType())
        //    {
        //        context.Reject(
        //            error: OpenIdConnectConstants.Errors.UnsupportedGrantType,
        //            description: "Only resource owner password credentials and refresh token " +
        //                         "are accepted by this authorization server");

        //        return Task.FromResult(0);
        //    }

        //    // Reject the token request if client_id or client_secret is missing.
        //    if (string.IsNullOrEmpty(context.ClientId) || string.IsNullOrEmpty(context.ClientSecret))
        //    {
        //        context.Reject(
        //            error: OpenIdConnectConstants.Errors.InvalidRequest,
        //            description: "Missing credentials: ensure that your credentials were correctly " +
        //                         "flowed in the request body or in the authorization header");

        //        return Task.FromResult(0);
        //    }

        //    // Note: to mitigate brute force attacks, you SHOULD strongly consider applying
        //    // a key derivation function like PBKDF2 to slow down the secret validation process.
        //    // You SHOULD also consider using a time-constant comparer to prevent timing attacks.
        //    // For that, you can use the CryptoHelper library developed by @henkmollema:
        //    // https://github.com/henkmollema/CryptoHelper. If you don't need .NET Core support,
        //    // SecurityDriven.NET/inferno is a rock-solid alternative: http://securitydriven.net/inferno/
        //    if (string.Equals(context.ClientId, "client_id", StringComparison.Ordinal) &&
        //        string.Equals(context.ClientSecret, "client_secret", StringComparison.Ordinal))
        //    {
        //        context.Validate();

        //        return Task.FromResult(0);
        //    }

        //    // Note: if Validate() is not explicitly called,
        //    // the request is automatically rejected.
        //    return Task.FromResult(0);
        //}


        //public override async Task ValidateTokenRequest(ValidateTokenRequestContext context)
        //{
        //    var database = context.HttpContext.RequestServices.GetRequiredService<ApplicationContext>();

        //    // Reject the token request that don't use grant_type=password or grant_type=refresh_token.
        //    if (!context.Request.IsPasswordGrantType() && !context.Request.IsRefreshTokenGrantType())
        //    {
        //        context.Reject(
        //            error: OpenIdConnectConstants.Errors.UnsupportedGrantType,
        //            description: "Only resource owner password credentials and refresh token " +
        //                         "are accepted by this authorization server");

        //        return;
        //    }

        //    // Skip client authentication if the client identifier is missing.
        //    // Note: ASOS will automatically ensure that the calling application
        //    // cannot use an authorization code or a refresh token if it's not
        //    // the intended audience, even if client authentication was skipped.
        //    if (string.IsNullOrEmpty(context.ClientId))
        //    {
        //        context.Skip();

        //        return;
        //    }

        //    // Retrieve the application details corresponding to the requested client_id.
        //    var application = await (from entity in database.Applications
        //                             where entity.ApplicationID == context.ClientId
        //                             select entity).SingleOrDefaultAsync(context.HttpContext.RequestAborted);

        //    if (application == null)
        //    {
        //        context.Reject(
        //            error: OpenIdConnectConstants.Errors.InvalidClient,
        //            description: "Application not found in the database: ensure that your client_id is correct.");

        //        return;
        //    }

        //    if (application.Type == ApplicationType.Public)
        //    {
        //        // Reject tokens requests containing a client_secret
        //        // if the client application is not confidential.
        //        if (!string.IsNullOrEmpty(context.ClientSecret))
        //        {
        //            context.Reject(
        //                error: OpenIdConnectConstants.Errors.InvalidRequest,
        //                description: "Public clients are not allowed to send a client_secret.");

        //            return;
        //        }

        //        // If client authentication cannot be enforced, call context.Skip() to inform
        //        // the OpenID Connect server middleware that the caller cannot be fully trusted.
        //        context.Skip();

        //        return;
        //    }

        //    // Confidential applications MUST authenticate
        //    // to protect them from impersonation attacks.
        //    if (string.IsNullOrEmpty(context.ClientSecret))
        //    {
        //        context.Reject(
        //            error: OpenIdConnectConstants.Errors.InvalidClient,
        //            description: "Missing credentials: ensure that you specified a client_secret.");

        //        return;
        //    }

        //    // Note: to mitigate brute force attacks, you SHOULD strongly consider applying
        //    // a key derivation function like PBKDF2 to slow down the secret validation process.
        //    // You SHOULD also consider using a time-constant comparer to prevent timing attacks.
        //    // For that, you can use the CryptoHelper library developed by @henkmollema:
        //    // https://github.com/henkmollema/CryptoHelper. If you don't need .NET Core support,
        //    // SecurityDriven.NET/inferno is a rock-solid alternative: http://securitydriven.net/inferno/
        //    if (!string.Equals(context.ClientSecret, application.Secret, StringComparison.Ordinal))
        //    {
        //        context.Reject(
        //            error: OpenIdConnectConstants.Errors.InvalidClient,
        //            description: "Invalid credentials: ensure that you specified a correct client_secret.");

        //        return;
        //    }

        //    context.Validate();
        //}


        //public override async Task HandleTokenRequest(HandleTokenRequestContext context)
        //{
        //    // Resolve ASP.NET Core Identity's user manager from the DI container.
        //    var manager = context.HttpContext.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();

        //    // Only handle grant_type=password requests and let ASOS
        //    // process grant_type=refresh_token requests automatically.
        //    if (context.Request.IsPasswordGrantType())
        //    {
        //        var user = await manager.FindByNameAsync(context.Request.Username);
        //        if (user == null)
        //        {
        //            context.Reject(
        //                error: OpenIdConnectConstants.Errors.InvalidGrant,
        //                description: "Invalid credentials.");

        //            return;
        //        }

        //        // Ensure the user is not already locked out.
        //        if (manager.SupportsUserLockout && await manager.IsLockedOutAsync(user))
        //        {
        //            context.Reject(
        //                error: OpenIdConnectConstants.Errors.InvalidGrant,
        //                description: "Invalid credentials.");

        //            return;
        //        }

        //        // Ensure the password is valid.
        //        if (!await manager.CheckPasswordAsync(user, context.Request.Password))
        //        {
        //            if (manager.SupportsUserLockout)
        //            {
        //                await manager.AccessFailedAsync(user);
        //            }

        //            context.Reject(
        //                error: OpenIdConnectConstants.Errors.InvalidGrant,
        //                description: "Invalid credentials.");

        //            return;
        //        }

        //        if (manager.SupportsUserLockout)
        //        {
        //            await manager.ResetAccessFailedCountAsync(user);
        //        }

        //        // Reject the token request if two-factor authentication has been enabled by the user.
        //        if (manager.SupportsUserTwoFactor && await manager.GetTwoFactorEnabledAsync(user))
        //        {
        //            context.Reject(
        //                error: OpenIdConnectConstants.Errors.InvalidGrant,
        //                description: "Two-factor authentication is required for this account.");

        //            return;
        //        }

        //        var identity = new ClaimsIdentity(context.Options.AuthenticationScheme);

        //        // Note: the name identifier is always included in both identity and
        //        // access tokens, even if an explicit destination is not specified.
        //        identity.AddClaim(ClaimTypes.NameIdentifier, await manager.GetUserId(user));

        //        // When adding custom claims, you MUST specify one or more destinations.
        //        // Read "part 7" for more information about custom claims and scopes.
        //        identity.AddClaim("username", await manager.GetUserNameAsync(user),
        //            OpenIdConnectConstants.Destinations.AccessToken,
        //            OpenIdConnectConstants.Destinations.IdentityToken);

        //        // Create a new authentication ticket holding the user identity.
        //        var ticket = new AuthenticationTicket(
        //            new ClaimsPrincipal(identity),
        //            new AuthenticationProperties(),
        //            context.Options.AuthenticationScheme);

        //        // Set the list of scopes granted to the client application.
        //        ticket.SetScopes(
        //            /* openid: */ OpenIdConnectConstants.Scopes.OpenId,
        //            /* email: */ OpenIdConnectConstants.Scopes.Email,
        //            /* profile: */ OpenIdConnectConstants.Scopes.Profile);

        //        // Set the resource servers the access token should be issued for.
        //        ticket.SetResources("resource_server");

        //        context.Validate(ticket);
        //    }
        //}

    }
}
