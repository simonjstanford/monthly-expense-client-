# monthly-expenses

A personal expenses tool used to track your month by month income and outgoings.

[![.NET](https://github.com/simonjstanford/monthly-expenses/actions/workflows/dotnet.yml/badge.svg)](https://github.com/simonjstanford/monthly-expenses/actions/workflows/dotnet.yml)\
[![Azure Static Web Apps CI/CD](https://github.com/simonjstanford/monthly-expenses/workflows/Azure%20Static%20Web%20Apps%20CI%2FCD/badge.svg)](https://github.com/simonjstanford/monthly-expenses/actions/workflows/deploy.yml)

## Technical details:

This project uses the following tech:

- Angular in TypeScript for the front end
- Azure Functions in C# as the API
- Azure Table Storage as the document database, encrypted at rest
- Deployed to Azure Static Web Apps using a GitHub Action CI/CD pipeline
- OAuth2 for authentication
- Application Insights for logging
- StyleCop for the API style enforcement
- Sonar for the API for static code analysis
- Swagger for OpenAPI
- xUnit, Moq and FluentAssertions for the C# unit tests
