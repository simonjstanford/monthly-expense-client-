// <copyright file="OpenApiConfigurationOptions.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;

namespace MonthlyExpenses.Api.Authentication;

public class OpenApiConfigurationOptions : DefaultOpenApiConfigurationOptions
{
#pragma warning disable S1075 // URIs should not be hardcoded
    private const string IssuesUrl = "https://github.com/simonjstanford/monthly-expenses/issues";
    private const string UriString = "https://github.com/simonjstanford/monthly-expenses/blob/main/LICENSE";
#pragma warning restore S1075 // URIs should not be hardcoded

    public override OpenApiInfo Info { get; set; } =
      new OpenApiInfo
      {
          Title = "Monthly Expenses API Documentation",
          Version = "1.0",
          Description = "An API used by the monthly expenses app to handle user expense requests",
          Contact = new OpenApiContact()
          {
              Name = "Simon Stanford",
              Url = new Uri(IssuesUrl),
          },
          License = new OpenApiLicense()
          {
              Name = "MIT",
              Url = new Uri(UriString),
          },
      };

    public override OpenApiVersionType OpenApiVersion { get; set; } = OpenApiVersionType.V3;
}
