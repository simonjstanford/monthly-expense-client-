using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api.Test.Helpers;

internal class Creator
{
    internal static UserExpenses CreateExpenses(string userName)
    {
        return new UserExpenses
        {
            User = userName,
            Months = new[]
            {
                CreateMonthData(),
            },
        };
    }

    internal static MonthData CreateMonthData()
    {
        return new MonthData
        {
            MonthStart = new DateTime(2023, 6, 1),
            Income = new[]
            {
                new Expense("Salary", 2000),
                new Expense("Overtime", 200),
            },
            Outgoings = new[]
            {
                new Expense("Rent", 500),
                new Expense("Car", 100),
                new Expense("Phone", 30),
                new Expense("Internet", 40),
                new Expense("Food", 300),
            },
        };
    }
}
