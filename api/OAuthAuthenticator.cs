using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MonthlyExpenses.Api.Interfaces;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using MonthlyExpenses.Api.Models;
using Microsoft.Extensions.Logging;

namespace MonthlyExpenses.Api;

public class OAuthAuthenticator : IAuthenticator
{
    private const string cookieName = "StaticWebAppsAuthCookie";

    public Task<(string user, bool isAuthenticated)> AuthenticateRequest(HttpRequest req, ILogger logger)
    {
        logger.LogInformation("Getting Claims Principal");

        var principal = new ClientPrincipal();

        if (req.Cookies.TryGetValue(cookieName, out var cookie))
        {
            var decoded = Convert.FromBase64String(cookie);
            var json = Encoding.UTF8.GetString(decoded);
            principal = JsonSerializer.Deserialize<ClientPrincipal>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        else
        {
            logger.LogError($"Unable to find cookie {cookieName}");
            return Task.FromResult((string.Empty, false));
        }

        principal.UserRoles = principal.UserRoles?.Except(new string[] { "anonymous" }, StringComparer.CurrentCultureIgnoreCase);

        if (!principal.UserRoles?.Any() ?? true)
        {
            logger.LogError($"No roles associated with principal {principal.UserDetails}");
            return Task.FromResult((principal.UserDetails, false));
        }

        var identity = new ClaimsIdentity(principal.IdentityProvider);
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, principal.UserId));
        identity.AddClaim(new Claim(ClaimTypes.Name, principal.UserDetails));
        identity.AddClaims(principal.UserRoles.Select(r => new Claim(ClaimTypes.Role, r)));

        var claimsPrincipal = new ClaimsPrincipal(identity);
        if (!claimsPrincipal.Identity.IsAuthenticated || !claimsPrincipal.IsInRole("authenticated"))
        {
            logger.LogError($"Principal {claimsPrincipal.Identity.Name} is not authorised: {claimsPrincipal.Identity.IsAuthenticated}, {claimsPrincipal.IsInRole("authenticated")}");
            return Task.FromResult((claimsPrincipal.Identity.Name, false));
        }

        logger.LogInformation($"Principal {claimsPrincipal.Identity.Name} is authorised for monthexpenses GET");
        return Task.FromResult((claimsPrincipal.Identity.Name, true));
    }
}