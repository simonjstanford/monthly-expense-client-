// <copyright file="Expense.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using System.Text.Json.Serialization;

namespace MonthlyExpenses.Api.Models;

public readonly record struct Expense(
    [property:JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("value")] decimal Value);