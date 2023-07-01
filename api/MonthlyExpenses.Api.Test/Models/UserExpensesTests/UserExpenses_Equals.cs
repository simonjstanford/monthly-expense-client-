using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api.Test.Models.UserExpensesTests;

public class UserExpenses_Equaals : BaseUserExpensesTests
{
    protected override bool TestEquals(UserExpenses expenses1, UserExpenses expenses2)
    {
        object obj = expenses2;
        return expenses1.Equals(obj);
    }
}
