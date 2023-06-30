// <copyright file="TableClientWrapper.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;

namespace MonthlyExpenses.Api.Repository;

public class TableClientWrapper : ITableClient
{
    private readonly TableClient tableClient;

    public TableClientWrapper(TableClient tableClient)
    {
        this.tableClient = tableClient;
    }

    public Task AddEntityAsync<T>(T entity)
        where T : ITableEntity
    {
        return tableClient.AddEntityAsync(entity);
    }

    public Task<NullableResponse<T>> GetEntityIfExistsAsync<T>(string partitionKey, string id)
        where T : class, ITableEntity
    {
        return tableClient.GetEntityIfExistsAsync<T>(partitionKey, id);
    }
}
