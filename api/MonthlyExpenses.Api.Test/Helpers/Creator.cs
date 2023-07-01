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
            Income = new Dictionary<string, decimal>
            {
                { "Salary", 2000 },
                { "Overtime", 200 },
            },
            Outgoings = new Dictionary<string, decimal>
            {
                { "Rent", 500 },
                { "Car", 100 },
                { "Phone", 30 },
                { "Internet", 40 },
                { "Food", 300 },
            },
        };
    }
}
