// <copyright file="UserExpenseEntity.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using Azure;
using Azure.Data.Tables;

namespace MonthlyExpenses.Api.Repository;

public record UserExpenseEntity : ITableEntity
{
    public string RowKey { get; set; } = default!;

    public string PartitionKey { get; set; } = default!;

    public ETag ETag { get; set; } = default!;

    public DateTimeOffset? Timestamp { get; set; } = default!;

    public byte[] Expenses { get; set; }
}
