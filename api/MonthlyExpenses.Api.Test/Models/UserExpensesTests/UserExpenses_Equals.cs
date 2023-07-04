// <copyright file="UserExpenses_Equals.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api.Test.Models.UserExpensesTests;

public class UserExpenses_Equals : BaseUserExpensesTests
{
    protected override bool TestEquals(UserExpenses expenses1, UserExpenses expenses2)
    {
        object obj = expenses2;
        return expenses1.Equals(obj);
    }
}
