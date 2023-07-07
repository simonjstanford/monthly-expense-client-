// <copyright file="BaseUserExpensesTests.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using FluentAssertions;
using MonthlyExpenses.Api.Enums;
using MonthlyExpenses.Api.Models;
using MonthlyExpenses.Api.Test.Helpers;

namespace MonthlyExpenses.Api.Test.Models.UserExpensesTests;

public abstract class BaseUserExpensesTests
{
    [Fact]
    public void Equals_WhenNullObject_ShouldReturnFalse()
    {
        var expense1 = new UserExpenses();
        var result = expense1.Equals(null);
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenSameObject_ShouldReturnTrue()
    {
        var expense1 = new UserExpenses();
        var expense2 = expense1;
        var result = expense1.Equals(expense2);
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_WhenDifferentObject_SameName_ShouldReturnTrue()
    {
        var expense1 = Creator.CreateExpenses();
        var expense2 = Creator.CreateExpenses();
        var result = expense1.Equals(expense2);
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_WhenDifferentObject_DifferentName_ShouldReturnFalse()
    {
        var expense1 = Creator.CreateExpenses();
        var expense2 = Creator.CreateExpenses("User2");
        var result = expense1.Equals(expense2);
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenDifferentObject_DifferentMonths_ShouldReturnFalse()
    {
        var expense1 = Creator.CreateExpenses();
        var expense2 = Creator.CreateExpenses();
        expense2.Months[0].MonthStart = DateTime.Now;
        var result = expense1.Equals(expense2);
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenDifferentObject_ExtraMonths_ShouldReturnFalse()
    {
        var expense1 = Creator.CreateExpenses();
        var expense2 = Creator.CreateExpenses();
        expense2.Months = new[]
        {
            Creator.CreateMonthData(),
            Creator.CreateMonthData(),
        };

        var result = expense1.Equals(expense2);
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenDifferentObject_MonthsWithDifferentValues_ShouldReturnFalse()
    {
        var expense1 = Creator.CreateExpenses();
        var expense2 = Creator.CreateExpenses();
        expense2.Months[0].Income[0] = new Expense("Salary", 40);
        var result = expense1.Equals(expense2);
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenDifferentObject_MonthlyWithDifferentValues_ShouldReturnFalse()
    {
        var expense1 = Creator.CreateExpenses();
        var expense2 = Creator.CreateExpenses();
        expense2.MonthlyExpenses[0] = new MonthlyExpense("Montly 2", 10000, DateTime.Now, DateTime.MinValue);
        var result = expense1.Equals(expense2);
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenDifferentObject_MonthlyWithExtraValues_ShouldReturnFalse()
    {
        var expense1 = Creator.CreateExpenses();
        var expense2 = Creator.CreateExpenses();
        expense2.MonthlyExpenses = new[]
        {
            new MonthlyExpense("Montly 1", 500, new DateTime(2023, 6, 1), DateTime.MaxValue),
            new MonthlyExpense("Montly 2", 10000, DateTime.Now, DateTime.MinValue),
        };
        var result = expense1.Equals(expense2);
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenDifferentObject_AnnaulWithDifferentValues_ShouldReturnFalse()
    {
        var expense1 = Creator.CreateExpenses();
        var expense2 = Creator.CreateExpenses();
        expense2.AnnualExpenses[0] = new AnnualExpense("Annual 2", 10000, Month.January, DateTime.Now, DateTime.MinValue);
        var result = expense1.Equals(expense2);
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenDifferentObject_AnnaulWithExtraValues_ShouldReturnFalse()
    {
        var expense1 = Creator.CreateExpenses();
        var expense2 = Creator.CreateExpenses();
        expense2.AnnualExpenses = new[]
        {
            new AnnualExpense("Annual 1", 500, Month.June, new DateTime(2023, 6, 1), DateTime.MaxValue),
            new AnnualExpense("Annual 2", 10000, Month.January, DateTime.Now, DateTime.MinValue),
        };
        var result = expense1.Equals(expense2);
        result.Should().BeFalse();
    }

    protected abstract bool TestEquals(UserExpenses expenses1, UserExpenses expenses2);
}
