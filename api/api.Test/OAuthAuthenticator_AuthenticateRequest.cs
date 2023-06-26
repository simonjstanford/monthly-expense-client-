using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MonthlyExpenses.Api;
using Moq;

namespace api.Test;

public class OAuthAuthenticator_AuthenticateRequest
{
    [Fact]
    public void AuthenticateRequest_WhenNoRequest_ShouldThrowException()
    {
        Assert.Throws<ArgumentNullException>(() => TestAuthenticateRequest(null!));
    }

    private static void TestAuthenticateRequest(HttpRequest request)
    {
        var mockLogger = new Mock<ILogger>();
        var sut = new OAuthAuthenticator();
        sut.AuthenticateRequest(request, mockLogger.Object);
    }
}