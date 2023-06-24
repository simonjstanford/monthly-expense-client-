// <copyright file="ClientAuthenticationException.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;

namespace MonthlyExpenses.Api.Models
{
    public class ClientAuthenticationException : Exception
    {
        public ClientAuthenticationException(string message)
            : base(message)
        {
        }
    }
}