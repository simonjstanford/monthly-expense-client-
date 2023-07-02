using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonthlyExpenses.Api.Functions;
using MonthlyExpenses.Api.Interfaces;
using MonthlyExpenses.Api.Models;
using Moq;
using System.Web.Http;

namespace MonthlyExpenses.Api.Test;

public class GetUserExpensesFunction_GetUserExpenses
{
    [Fact]
    public async Task GetUserExpenses_WhenAutenticatorThrowsClientAuthenticationException_ShouldReturnUnauthorizedResult()
    {
        var (sut, _, authenticator) = Setup();
        authenticator.Setup(x => x.AuthenticateRequest(It.IsAny<HttpRequest>(), It.IsAny<ILogger>())).Throws<ClientAuthenticationException>();
        var result = await GetUserExpenses(sut);
        result.Should().BeOfType<UnauthorizedResult>();
    }

    [Fact]
    public async Task GetUserExpenses_WhenRepositoryThrowsException_ShouldReturnInternalServerErrorResult()
    {
        var (sut, repo, _) = Setup();
        repo.Setup(x => x.GetUserExpenses(It.IsAny<User>(), It.IsAny<ILogger>())).Throws<Exception>();
        var result = await GetUserExpenses(sut);
        result.Should().BeOfType<InternalServerErrorResult>();
    }

    [Fact]
    public async Task GetUserExpenses_WhenRepositoryReturnsNull_ShouldReturnNotFoundResult()
    {
        var (sut, repo, _) = Setup();
        repo.Setup(x => x.GetUserExpenses(It.IsAny<User>(), It.IsAny<ILogger>())).Returns(Task.FromResult<UserExpenses>(null!));
        var result = await GetUserExpenses(sut);
        result.Should().BeOfType<NotFoundResult>();
    }

    [Fact]
    public async Task GetUserExpenses_WhenRepositoryReturnsData_ShouldReturnNotFoundResult()
    {
        var (sut, repo, _) = Setup();
        var data = new UserExpenses();
        repo.Setup(x => x.GetUserExpenses(It.IsAny<User>(), It.IsAny<ILogger>())).Returns(Task.FromResult(data));
        var result = await GetUserExpenses(sut);
        result.Should().BeOfType<JsonResult>();
        ((JsonResult)result).Value.Should().Be(data);
    }

    private static (GetUserExpensesFunction sut, Mock<IRepository> repository, Mock<IAuthenticator> authenticator) Setup()
    {
        var repository = new Mock<IRepository>();
        var authenticator = new Mock<IAuthenticator>();
        var sut = new GetUserExpensesFunction(repository.Object, authenticator.Object);
        return (sut, repository, authenticator);
    }

    private static async Task<IActionResult> GetUserExpenses(GetUserExpensesFunction sut)
    {
        var logger = new Mock<ILogger>();
        var result = await sut.GetUserExpenses(null!, logger.Object);
        return result;
    }
}
