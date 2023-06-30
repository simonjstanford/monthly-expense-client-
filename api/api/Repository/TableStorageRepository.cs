// <copyright file="TableStorageRepository.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Microsoft.Extensions.Logging;
using MonthlyExpenses.Api.Interfaces;
using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api.Repository;

/// <inheritdoc/>
public class TableStorageRepository : IRepository
{
    private const string ConnectionStringEnvVariable = "StorageAccount_ConnectionString";
    private const string TableName = "expenses";
    private const string PartitionKey = "user-expense-data";

    /// <inheritdoc/>
    public async Task<UserExpenses> GetUserExpenses(string user, ILogger log)
    {
        try
        {
            var table = await GetExpensesTable();
            var entity = await table.GetEntityIfExistsAsync<UserExpenseEntity>(PartitionKey, user);

            if (entity?.HasValue == true && entity.Value?.Expenses is byte[] expensesBytes)
            {
                return Serializer.ByteArrayToObject<UserExpenses>(expensesBytes);
            }
            else
            {
                throw new Exception($"No expense data found for {user}");
            }
        }
        catch (Exception ex)
        {
            log.LogError($"Unable to fetch data from storage: {ex}");
            throw;
        }
    }

    public async Task SaveUserExpenses(string user, UserExpenses data, ILogger log)
    {
        try
        {
            var table = await GetExpensesTable();
            var entity = CreateEntity(user, data);
            await table.AddEntityAsync(entity);
        }
        catch (Exception ex)
        {
            log.LogError($"Unable to add data to storage: {ex}");
            throw;
        }
    }

    private static async Task<TableClient> GetExpensesTable()
    {
        var connectionString = Environment.GetEnvironmentVariable(ConnectionStringEnvVariable);
        var client = new TableServiceClient(connectionString);
        TableClient tableClient = client.GetTableClient(tableName: TableName);
        await tableClient.CreateIfNotExistsAsync();
        return tableClient;
    }

    private static UserExpenseEntity CreateEntity(string user, UserExpenses data)
    {
        return new UserExpenseEntity()
        {
            RowKey = user,
            PartitionKey = PartitionKey,
            Expenses = Serializer.ObjectToByteArray(data),
        };
    }
}