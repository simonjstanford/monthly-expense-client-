using System.Threading.Tasks;

namespace MonthlyExpenses.Api.Interfaces
{
    public interface IAuthenticator
    {
        Task<bool> IsValid();
    }
}