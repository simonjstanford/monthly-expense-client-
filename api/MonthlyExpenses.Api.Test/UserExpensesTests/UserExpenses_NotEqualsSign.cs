using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api.Test.UserExpensesTests
{
    public class UserExpenses_NotEqualsSign : BaseUserExpensesTests
    {
        protected override bool TestEquals(UserExpenses expenses1, UserExpenses expenses2)
        {
            return !(expenses1 != expenses2);
        }
    }
}
