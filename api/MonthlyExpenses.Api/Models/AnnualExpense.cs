// <copyright file="AnnualExpense.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using System.Text.Json.Serialization;
using MonthlyExpenses.Api.Enums;

namespace MonthlyExpenses.Api.Models;

public readonly record struct AnnualExpense(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("value")] decimal Value,
    [property: JsonPropertyName("month")] Month Month,
    [property: JsonPropertyName("startDate")] DateTime StartDate,
    [property: JsonPropertyName("endDate")] DateTime EndDate);