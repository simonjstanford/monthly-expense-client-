// <copyright file="TableClientFactory.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Azure.Data.Tables;

namespace MonthlyExpenses.Api.Repository.Repository;

public class TableClientFactory : ITableClientFactory
{
    private const string ConnectionStringEnvVariable = "StorageAccount_ConnectionString";
    private const string TableName = "expenses";

    public async Task<ITableClient> GetExpensesTable()
    {
        var connectionString = Environment.GetEnvironmentVariable(ConnectionStringEnvVariable);
        var client = new TableServiceClient(connectionString);
        TableClient tableClient = client.GetTableClient(tableName: TableName);
        await tableClient.CreateIfNotExistsAsync();
        return new TableClientWrapper(tableClient);
    }
}
