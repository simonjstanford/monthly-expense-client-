// <copyright file="Startup.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

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
            builder.Services.AddLogging();
            builder.Services.AddSingleton<IRepository, Repository>();
            builder.Services.AddSingleton<IAuthenticator, OAuthAuthenticator>();
        }
    }
}