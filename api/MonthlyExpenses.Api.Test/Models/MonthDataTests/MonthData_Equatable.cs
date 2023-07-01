using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api.Test.Models.UserExpensesTests;

public class MonthData_Equatable : BaseMonthDataTests
{
    protected override bool TestEquals(MonthData data1, MonthData data2)
    {
        var equatable = (IEquatable<MonthData>)data1;
        return equatable.Equals(data2);
    }
}
