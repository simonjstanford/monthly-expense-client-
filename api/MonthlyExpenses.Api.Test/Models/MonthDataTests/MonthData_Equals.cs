// <copyright file="MonthData_Equals.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api.Test.Models.UserExpensesTests;

public class MonthData_Equals : BaseMonthDataTests
{
    protected override bool TestEquals(MonthData data1, MonthData data2)
    {
        object obj = data2;
        return data1.Equals(obj);
    }
}
