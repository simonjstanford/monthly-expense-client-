using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api.Test.Models.UserExpensesTests;

public class MonthData_NotEqualsSign : BaseMonthDataTests
{
    protected override bool TestEquals(MonthData data1, MonthData data2) => !(data1 == data2);
}
