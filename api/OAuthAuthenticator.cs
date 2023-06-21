using System.Threading.Tasks;
using MonthlyExpenses.Api.Interfaces;

namespace MonthlyExpenses.Api;

public class OAuthAuthenticator : IAuthenticator
{
    public Task<bool> IsValid()
    {
        return Task.FromResult(true);
    }
}