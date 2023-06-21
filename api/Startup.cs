using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MonthlyExpenses.Api.Interfaces;

[assembly: FunctionsStartup(typeof(MonthlyExpenses.Api.Startup))]

namespace MonthlyExpenses.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IRepository, Repository>();
            builder.Services.AddSingleton<IAuthenticator, OAuthAuthenticator>();
        }
    }
}