using FluentAssertions;
using MonthlyExpenses.Api.Models;
using MonthlyExpenses.Api.Test.Helpers;

namespace MonthlyExpenses.Api.Test.UserExpensesTests;

public abstract class BaseUserExpensesTests
{
    [Fact]
    public void Equals_WhenNullObject_ShouldReturnTrue()
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
        var expense1 = Creator.CreateExpenses("User1");
        var expense2 = Creator.CreateExpenses("User1");
        var result = expense1.Equals(expense2);
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_WhenDifferentObject_DifferentName_ShouldReturnTrue()
    {
        var expense1 = Creator.CreateExpenses("User1");
        var expense2 = Creator.CreateExpenses("User2");
        var result = expense1.Equals(expense2);
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenDifferentObject_DifferentMonths_ShouldReturnTrue()
    {
        var expense1 = Creator.CreateExpenses("User1");
        var expense2 = Creator.CreateExpenses("User1");
        expense2.Months[0].MonthStart = DateTime.Now;
        var result = expense1.Equals(expense2);
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenDifferentObject_ExtraMonths_ShouldReturnTrue()
    {
        var expense1 = Creator.CreateExpenses("User1");
        var expense2 = Creator.CreateExpenses("User1");
        expense2.Months = new[]
        {
            Creator.CreateMonthData(),
            Creator.CreateMonthData(),
        };

        var result = expense1.Equals(expense2);
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WhenDifferentObject_MonthsWithDifferentValues_ShouldReturnTrue()
    {
        var expense1 = Creator.CreateExpenses("User1");
        var expense2 = Creator.CreateExpenses("User1");
        expense2.Months[0].Income["Salary"] = 40;
        var result = expense1.Equals(expense2);
        result.Should().BeFalse();
    }

    protected abstract bool TestEquals(UserExpenses expenses1, UserExpenses expenses2);
}
