// <copyright file="MonthlyExpense.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using System.Text.Json.Serialization;

namespace MonthlyExpenses.Api.Models;

public readonly record struct MonthlyExpense(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("value")] decimal Value,
    [property: JsonPropertyName("startDate")] DateTime StartDate,
    [property: JsonPropertyName("endDate")] DateTime EndDate);