// <copyright file="Serializer_Serialize.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using FluentAssertions;
using MonthlyExpenses.Api.Models;
using MonthlyExpenses.Api.Test.Helpers;
using MonthlyExpenses.Api.Utils;

namespace MonthlyExpenses.Api.Test.Utils;

public class Serializer_Serialize
{
    private const string Json = "{\"user\":\"User1\",\"months\":[{\"monthStart\":\"2023-06-01T00:00:00\",\"income\":[{\"name\":\"Salary\",\"value\":2000},{\"name\":\"Overtime\",\"value\":200}],\"outgoings\":[{\"name\":\"Rent\",\"value\":500},{\"name\":\"Car\",\"value\":100},{\"name\":\"Phone\",\"value\":30},{\"name\":\"Internet\",\"value\":40},{\"name\":\"Food\",\"value\":300}]}],\"annualExpenses\":[{\"name\":\"Annual 1\",\"value\":500,\"month\":6,\"startDate\":\"2023-06-01T00:00:00\",\"endDate\":\"9999-12-31T23:59:59.9999999\"}],\"monthlyExpenses\":[{\"name\":\"Montly 1\",\"value\":500,\"startDate\":\"2023-06-01T00:00:00\",\"endDate\":\"9999-12-31T23:59:59.9999999\"}]}";

    [Fact]
    public void Serialize_ShouldSerializeIntoLowerCase()
    {
        var expenses = Creator.CreateExpenses();
        var json = Serializer.Serialize(expenses);
        json.Should().Be(Json);
    }

    [Fact]
    public void Deserialize_ShouldKeepData()
    {
        var expenseData = Serializer.Deserialize<UserExpenses>(Json);
        var expectedExpense = Creator.CreateExpenses();
        expenseData.Should().Be(expectedExpense);
    }
}
