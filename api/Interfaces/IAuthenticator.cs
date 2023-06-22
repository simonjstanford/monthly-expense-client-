using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MonthlyExpenses.Api.Interfaces
{
    public interface IAuthenticator
    {
        Task<(string user, bool isAuthenticated)> AuthenticateRequest(HttpRequest req, ILogger logger);
    }
}