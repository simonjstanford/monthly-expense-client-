// <copyright file="UserExpenses_EqualsSign.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api.Test.Models.UserExpensesTests;

public class UserExpenses_EqualsSign : BaseUserExpensesTests
{
    protected override bool TestEquals(UserExpenses expenses1, UserExpenses expenses2)
    {
        return expenses1 == expenses2;
    }
}
