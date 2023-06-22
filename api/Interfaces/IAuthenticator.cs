using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MonthlyExpenses.Api.Interfaces
{
    public interface IAuthenticator
    {
        Task<ClaimsPrincipal> GetClaimsPrincipal(HttpRequest req, ILogger logger);
    }
}