using FluentAssertions;
using MonthlyExpenses.Api.Models;
using MonthlyExpenses.Api.Test.Helpers;

namespace MonthlyExpenses.Api.Test.Models.UserExpensesTests;

public abstract class BaseMonthDataTests
{
    [Fact]
    public void Equals_WhenNullObject_ShouldReturnTrue()
    {
        var data = new MonthData();
        var result = data.Equals(null);
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenSameObject_ShouldReturnTrue()
    {
        var data1 = new MonthData();
        var data2 = data1;
        var result = data1.Equals(data2);
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_WhenDifferentObject_SameData_ShouldReturnTrue()
    {
        var data1 = Creator.CreateMonthData();
        var data2 = Creator.CreateMonthData();
        var result = data1.Equals(data2);
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_WhenDifferentObject_DifferentMonths_ShouldReturnTrue()
    {
        var data1 = Creator.CreateMonthData();
        var data2 = Creator.CreateMonthData();
        data2.MonthStart = DateTime.Now;
        var result = data1.Equals(data2);
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenDifferentObject_MonthsWithDifferentIncomeValues_ShouldReturnTrue()
    {
        var data1 = Creator.CreateMonthData();
        var data2 = Creator.CreateMonthData();
        data2.Income[0] = new Expense("Salary", 40);
        var result = data1.Equals(data2);
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenDifferentObject_MonthsWithDifferentOutgoingValues_ShouldReturnTrue()
    {
        var data1 = Creator.CreateMonthData();
        var data2 = Creator.CreateMonthData();
        data2.Outgoings[0] = new Expense("Rent", 1000);
        var result = data1.Equals(data2);
        result.Should().BeFalse();
    }

    protected abstract bool TestEquals(MonthData data1, MonthData data2);
}
