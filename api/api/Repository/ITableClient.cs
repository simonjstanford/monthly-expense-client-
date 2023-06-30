// <copyright file="ITableClient.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;

namespace MonthlyExpenses.Api.Repository;

public interface ITableClient
{
    Task AddEntityAsync<T>(T entity)
        where T : ITableEntity;

    Task<NullableResponse<T>> GetEntityIfExistsAsync<T>(string partitionKey, string id)
        where T : class, ITableEntity;
}
