using MonthlyExpenses.Api.Models;
using System;

namespace MonthlyExpenses.Api.Test.UserExpensesTests
{
    public class UserExpenses_EqualsSign : BaseUserExpensesTests
    {
        protected override bool TestEquals(UserExpenses expenses1, UserExpenses expenses2)
        {
            return expenses1 == expenses2;
        }
    }
}
