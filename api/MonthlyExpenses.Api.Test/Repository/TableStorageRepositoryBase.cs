// <copyright file="TableStorageRepositoryBase.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using MonthlyExpenses.Api.Models;
using MonthlyExpenses.Api.Repository;
using MonthlyExpenses.Api.Repository.Repository;
using Moq;

namespace MonthlyExpenses.Api.Test.Repository;

public abstract class TableStorageRepositoryBase
{
    protected const string EntityId = "123";
    protected const string UserName = "Test User";

    protected static User CreateUser() => new(EntityId, UserName);

    protected static (TableStorageRepository Sut, Mock<ITableClient> Table) Setup()
    {
        var factory = new Mock<ITableClientFactory>();
        var table = new Mock<ITableClient>();
        factory.Setup(x => x.GetExpensesTable()).Returns(Task.FromResult(table.Object));
        var sut = new TableStorageRepository(factory.Object);
        return (sut, table);
    }
}
