using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MonthlyExpenses.Api.Interfaces;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api;

public class OAuthAuthenticator : IAuthenticator
{
    public Task<ClaimsPrincipal> GetClaimsPrincipal(HttpRequest req)
    {
        var principal = new ClientPrincipal();

        if (req.Headers.TryGetValue("x-ms-client-principal", out var header))
        {
            var data = header[0];
            var decoded = Convert.FromBase64String(data);
            var json = Encoding.UTF8.GetString(decoded);
            principal = JsonSerializer.Deserialize<ClientPrincipal>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        principal.UserRoles = principal.UserRoles?.Except(new string[] { "anonymous" }, StringComparer.CurrentCultureIgnoreCase);

        if (!principal.UserRoles?.Any() ?? true)
        {
            return Task.FromResult(new ClaimsPrincipal());
        }

        var identity = new ClaimsIdentity(principal.IdentityProvider);
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, principal.UserId));
        identity.AddClaim(new Claim(ClaimTypes.Name, principal.UserDetails));
        identity.AddClaims(principal.UserRoles.Select(r => new Claim(ClaimTypes.Role, r)));

        return Task.FromResult(new ClaimsPrincipal(identity));
    }
}