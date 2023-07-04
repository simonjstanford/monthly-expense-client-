using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonthlyExpenses.Api.Functions;
using MonthlyExpenses.Api.Interfaces;
using MonthlyExpenses.Api.Models;
using MonthlyExpenses.Api.Test.Fakes;
using Moq;
using System.Web.Http;

namespace MonthlyExpenses.Api.Test;

public class PostUserExpensesFunction_PostUserExpenses
{
    [Fact]
    public async Task PostUserExpenses_WhenNotAuthenticated_ShouldReturnUnauthorizedResult()
    {
        var (sut, repository, authenticator) = Setup();
        authenticator.Setup(x => x.AuthenticateRequest(It.IsAny<HttpRequest>(), It.IsAny<ILogger>())).Throws<ClientAuthenticationException>();
        var request = FakeHttpRequests.CreateRequestWithoutHeader();
        var result = await PostUserExpenses(sut, request.Object);
        result.Should().BeOfType<UnauthorizedResult>();
    }

    [Fact]
    public async Task PostUserExpenses_WhenNoExpenseInBody_ShouldReturnBadRequestResult()
    {
        var (sut, _, _) = Setup();
        var request = FakeHttpRequests.CreateMockRequestWithBody(null!);
        var result = await PostUserExpenses(sut, request.Object);
        result.Should().BeOfType<BadRequestResult>();
    }

    [Fact]
    public async Task PostUserExpenses_WhenExpenseInBodyIsNotJson_ShouldReturnBadRequestResult()
    {
        var (sut, _, _) = Setup();
        var request = FakeHttpRequests.CreateMockRequestWithBody("Test", "application/text");
        var result = await PostUserExpenses(sut, request.Object);
        result.Should().BeOfType<BadRequestResult>();
    }

    [Fact]
    public async Task PostUserExpenses_WhenExpenseInBody_ShouldSave()
    {
        var (sut, repo, authenticator) = Setup();
        var expenses = CreateExpense();
        var request = FakeHttpRequests.CreateMockRequestWithBody(expenses);
        var user = AddUser(authenticator);
        var result = await PostUserExpenses(sut, request.Object);
        result.Should().BeOfType<OkResult>();
        repo.Verify(x => x.SaveUserExpenses(user, expenses, It.IsAny<ILogger>()));
    }

    [Fact]
    public async Task PostUserExpenses_WhenExceptionSaving_ShouldReturnInternalServerErrorResult()
    {
        var (sut, repo, authenticator) = Setup();
        var expenses = CreateExpense();
        var request = FakeHttpRequests.CreateMockRequestWithBody(expenses);
        var user = AddUser(authenticator);
        repo.Setup(x => x.SaveUserExpenses(user, expenses, It.IsAny<ILogger>())).Throws<Exception>();
        var result = await PostUserExpenses(sut, request.Object);
        result.Should().BeOfType<InternalServerErrorResult>();
    }

    private static User AddUser(Mock<IAuthenticator> authenticator)
    {
        var user = new User("123", "Test User");
        authenticator.Setup(x => x.AuthenticateRequest(It.IsAny<HttpRequest>(), It.IsAny<ILogger>())).Returns(Task.FromResult(user));
        return user;
    }

    private static UserExpenses CreateExpense()
    {
        return new UserExpenses() { User = "Test User" };
    }

    private static (PostUserExpensesFunction sut, Mock<IRepository> repository, Mock<IAuthenticator> authenticator) Setup()
    {
        var repository = new Mock<IRepository>();
        var authenticator = new Mock<IAuthenticator>();
        var sut = new PostUserExpensesFunction(repository.Object, authenticator.Object);
        return (sut, repository, authenticator);
    }

    private static async Task<IActionResult> PostUserExpenses(PostUserExpensesFunction sut, HttpRequest request)
    {
        var logger = new Mock<ILogger>();
        return await sut.PostUserExpenses(request, logger.Object);
    }
}
