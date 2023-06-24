// <copyright file="Repository.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MonthlyExpenses.Api.Interfaces;
using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api;

/// <inheritdoc/>
public class Repository : IRepository
{
    /// <inheritdoc/>
    public Task<UserExpenses> GetUserExpenses(string user)
    {
        var data = new UserExpenses
        {
            User = user,
            Months = new[]
            {
                new MonthData
                {
                    MonthStart = new DateTime(2023, 6, 1),
                    Income = new Dictionary<string, decimal>
                    {
                        { "Salary", 2000 },
                        { "Overtime", 200 },
                    },
                    Outgoings = new Dictionary<string, decimal>
                    {
                        { "Rent", 500 },
                        { "Car", 100 },
                        { "Phone", 30 },
                        { "Internet", 40 },
                        { "Food", 300 },
                    },
                },
            },
        };

        return Task.FromResult(data);
    }
}