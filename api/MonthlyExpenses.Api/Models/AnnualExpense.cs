// <copyright file="AnnualExpense.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using MonthlyExpenses.Api.Enums;

namespace MonthlyExpenses.Api.Models;

public readonly record struct AnnualExpense(
    string Name,
    decimal Value,
    Month Month,
    DateTime StartDate,
    DateTime EndDate);