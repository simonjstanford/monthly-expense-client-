// <copyright file="UserExpenses_Equatable.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api.Test.Models.UserExpensesTests;

public class UserExpenses_Equatable : BaseUserExpensesTests
{
    protected override bool TestEquals(UserExpenses expenses1, UserExpenses expenses2)
    {
        var equatable = (IEquatable<UserExpenses>)expenses1;
        return equatable.Equals(expenses2);
    }
}
