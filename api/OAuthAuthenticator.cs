// <copyright file="OAuthAuthenticator.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MonthlyExpenses.Api.Interfaces;
using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api;

/// <summary>
/// Authenticates a user using OAuth2.
/// Decodes user information in the x-ms-client-principal header.
/// This is an Azure Static Web Apps implementation where the authentication has been carried out automatically.
/// See https://learn.microsoft.com/en-us/azure/static-web-apps/authentication-authorization
/// And https://learn.microsoft.com/en-us/azure/static-web-apps/user-information?tabs=csharp
/// </summary>
public class OAuthAuthenticator : IAuthenticator
{
    private const string PrincipalHeader = "x-ms-client-principal";

    /// <inheritdoc/>
    public Task<string> AuthenticateRequest(HttpRequest req, ILogger logger)
    {
        logger.LogInformation("Getting Claims Principal");
        var clientPrincipal = GetClientPrincipal(req, logger);
        AssertClientPrincipalHasUserRoles(clientPrincipal);
        var claimsPrincipal = CreateClaimsPrincipal(clientPrincipal);
        AssertIsAuthenticated(claimsPrincipal);
        logger.LogInformation($"Principal {claimsPrincipal.Identity.Name} is authorised for monthexpenses GET");
        return Task.FromResult(claimsPrincipal.Identity.Name);
    }

    private static ClientPrincipal GetClientPrincipal(HttpRequest req, ILogger logger)
    {
        if (req.Headers.TryGetValue(PrincipalHeader, out var header))
        {
            var data = header.First();
            var decoded = Convert.FromBase64String(data);
            var json = Encoding.UTF8.GetString(decoded);
            logger.LogInformation($"x-ms-client-principal: {json}");
            var principal = JsonSerializer.Deserialize<ClientPrincipal>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            principal.UserRoles = principal.UserRoles?.Except(new string[] { "anonymous" }, StringComparer.CurrentCultureIgnoreCase);
            return principal;
        }

        throw new ClientAuthenticationException($"Unable to find cookie {PrincipalHeader}");
    }

    private static void AssertClientPrincipalHasUserRoles(ClientPrincipal principal)
    {
        if (!principal.UserRoles?.Any() ?? true)
        {
            throw new ClientAuthenticationException($"No roles associated with principal {principal.UserDetails}");
        }
    }

    private static ClaimsPrincipal CreateClaimsPrincipal(ClientPrincipal principal)
    {
        var identity = new ClaimsIdentity(principal.IdentityProvider);
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, principal.UserId));
        identity.AddClaim(new Claim(ClaimTypes.Name, principal.UserDetails));
        identity.AddClaims(principal.UserRoles.Select(r => new Claim(ClaimTypes.Role, r)));
        return new ClaimsPrincipal(identity);
    }

    private static void AssertIsAuthenticated(ClaimsPrincipal claimsPrincipal)
    {
        if (!claimsPrincipal.Identity.IsAuthenticated || !claimsPrincipal.IsInRole("authenticated"))
        {
            throw new ClientAuthenticationException(
                $"Principal {claimsPrincipal.Identity.Name} is not authorised: {claimsPrincipal.Identity.IsAuthenticated}, {claimsPrincipal.IsInRole("authenticated")}");
        }
    }
}