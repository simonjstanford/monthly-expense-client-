// <copyright file="IAuthenticator.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api.Interfaces;

/// <summary>
/// Represents a user authentication technique for protecting customer data.
/// </summary>
public interface IAuthenticator
{
    /// <summary>
    /// Authenticates a HTTP request.
    /// </summary>
    /// <returns>Information on the authenticated user.</returns>
    Task<User> AuthenticateRequest(HttpRequest req, ILogger logger);
}