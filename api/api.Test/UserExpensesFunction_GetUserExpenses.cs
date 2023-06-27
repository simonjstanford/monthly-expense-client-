using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MonthlyExpenses.Api;
using MonthlyExpenses.Api.Interfaces;
using MonthlyExpenses.Api.Models;
using Moq;

namespace api.Test
{
    public class UserExpensesFunction_GetUserExpenses
    {
        [Fact]
        public async Task GetUserExpenses_WhenAutenticatorThrowsClientAuthenticationException_ShouldReturnUnauthorizedResult()
        {
            var (sut, _, authenticator) = Setup();
            authenticator.Setup(x => x.AuthenticateRequest(It.IsAny<HttpRequest>(), It.IsAny<ILogger>())).Throws<ClientAuthenticationException>();
            var result = await GetUserExpenses(sut);
            result.Should().BeOfType<UnauthorizedResult>();
        }

        private static (UserExpensesFunction sut, Mock<IRepository> repository, Mock<IAuthenticator> authenticator) Setup()
        {
            var repository = new Mock<IRepository>();
            var authenticator = new Mock<IAuthenticator>();
            var sut = new UserExpensesFunction(repository.Object, authenticator.Object);
            return (sut, repository, authenticator);
        }

        private static async Task<IActionResult> GetUserExpenses(UserExpensesFunction sut)
        {
            var logger = new Mock<ILogger>();
            var result = await sut.GetUserExpenses(null!, logger.Object);
            return result;
        }
    }
}
