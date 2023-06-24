// <copyright file="IAuthenticator.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MonthlyExpenses.Api.Interfaces
{
    /// <summary>
    /// Represents a user authentication technique for protecting customer data.
    /// </summary>
    public interface IAuthenticator
    {
        /// <summary>
        /// Authenticates a HTTP request.
        /// </summary>
        /// <returns>The human readible name of the user.</returns>
        Task<string> AuthenticateRequest(HttpRequest req, ILogger logger);
    }
}