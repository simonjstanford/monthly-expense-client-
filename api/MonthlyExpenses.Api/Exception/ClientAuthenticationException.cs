// <copyright file="ClientAuthenticationException.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using System.Runtime.Serialization;

namespace MonthlyExpenses.Api.Models;

[Serializable]
public class ClientAuthenticationException : Exception
{
    public ClientAuthenticationException()
    {
    }

    public ClientAuthenticationException(string message)
        : base(message)
    {
    }

    protected ClientAuthenticationException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}