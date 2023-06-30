// <copyright file="ITableClientFactory.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System.Threading.Tasks;

namespace MonthlyExpenses.Api.Repository.Repository;

public interface ITableClientFactory
{
    Task<ITableClient> GetExpensesTable();
}
