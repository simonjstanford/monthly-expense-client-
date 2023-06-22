using System.Threading.Tasks;
using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api.Interfaces
{
    public interface IRepository
    {
        Task<UserExpenses> GetUserExpenses(string user);
    }
}