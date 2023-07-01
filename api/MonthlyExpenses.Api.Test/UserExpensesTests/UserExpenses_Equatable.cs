using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api.Test.UserExpensesTests
{
    public class UserExpenses_Equatable : BaseUserExpensesTests
    {
        protected override bool TestEquals(UserExpenses expenses1, UserExpenses expenses2)
        {
            var equatable = (IEquatable<UserExpenses>)expenses1;
            return equatable.Equals(expenses2);
        }
    }
}
