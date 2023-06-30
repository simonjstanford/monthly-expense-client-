using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MonthlyExpenses.Api.Authentication;
using MonthlyExpenses.Api.Models;
using MonthlyExpenses.Api.Test.Fakes;
using Moq;

namespace MonthlyExpenses.Api.Test;

public class OAuthAuthenticator_AuthenticateRequest
{
    [Fact]
    public void AuthenticateRequest_WhenNoRequest_ShouldThrowException()
    {
        Action action = () => TestAuthenticateRequest(null!);
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AuthenticateRequest_WhenNoClaimInHeader_ShouldThrowAuthenticateRequest()
    {
        var request = FakeHttpRequests.CreateRequestWithoutHeader();
        Action action = () => TestAuthenticateRequest(request.Object);
        action.Should().Throw<ClientAuthenticationException>();
    }

    [Fact]
    public void AuthenticateRequest_WhenOnlyAnonymousClaim_ShouldThrowAuthenticateRequest()
    {
        var request = FakeHttpRequests.CreateRequestWithoutAuthenticatedClaim();
        Action action = () => TestAuthenticateRequest(request.Object);
        action.Should().Throw<ClientAuthenticationException>();
    }

    [Fact]
    public void AuthenticateRequest_WhenNoAuthenticatedClaim_ShouldThrowAuthenticateRequest()
    {
        var request = FakeHttpRequests.CreateRequestWithRandomClaim();
        Action action = () => TestAuthenticateRequest(request.Object);
        action.Should().Throw<ClientAuthenticationException>();
    }

    [Fact]
    public void AuthenticateRequest_WhenIsAuthenticatedFalse_ShouldThrowAuthenticateRequest()
    {
        var request = FakeHttpRequests.CreateRequestWithUnAuthenticatedClaim();
        Action action = () => TestAuthenticateRequest(request.Object);
        action.Should().Throw<ClientAuthenticationException>();
    }

    [Fact]
    public async Task AuthenticateRequest_WhenClaimAuthenticated_ShouldThrowAuthenticateRequest()
    {
        var request = FakeHttpRequests.CreateRequestWithAuthenticatedClaim();
        var result = await TestAuthenticateRequest(request.Object);
        result.Name.Should().Be("Test User");
    }

    private static Task<User> TestAuthenticateRequest(HttpRequest request)
    {
        var mockLogger = new Mock<ILogger>();
        var sut = new OAuthAuthenticator();
        return sut.AuthenticateRequest(request, mockLogger.Object);
    }
}