// <copyright file="MonthlyExpense.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;

namespace MonthlyExpenses.Api.Models;

public readonly record struct MonthlyExpense(
    string Name,
    decimal Value,
    DateTime StartDate,
    DateTime EndDate);