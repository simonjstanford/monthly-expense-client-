// <copyright file="Expense.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

namespace MonthlyExpenses.Api.Models;

public readonly record struct Expense(string Name, decimal Value);