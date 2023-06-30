using MonthlyExpenses.Api.Models;
using System.Text;
using System.Text.Json;

namespace api.Test.Fakes;

internal static class FakeClaimsPrincipal
{
    public static string CreateClientPrincipalBase64(List<string>? userRoles = null, string identityProvider = "Test Provider")
    {
        ClientPrincipal principal = CreateClientPrincipal(userRoles, identityProvider);
        var json = JsonSerializer.Serialize(principal, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        var plainTextBytes = Encoding.UTF8.GetBytes(json);
        var base64 = Convert.ToBase64String(plainTextBytes);
        return base64;
    }

    private static ClientPrincipal CreateClientPrincipal(List<string>? userRoles, string identityProvider = "Test Provider")
    {
        var principal = new ClientPrincipal
        {
            IdentityProvider = identityProvider,
            UserDetails = "Test User",
            UserId = "123",
        };

        AddUserRoles(userRoles, principal);
        return principal;
    }

    private static void AddUserRoles(List<string>? userRoles, ClientPrincipal principal)
    {
        if (userRoles == null)
        {
            principal.UserRoles = new List<string>
            {
                "anonymous",
                "authenticated"
            };
        }
        else
        {
            principal.UserRoles = userRoles;
        }
    }
}