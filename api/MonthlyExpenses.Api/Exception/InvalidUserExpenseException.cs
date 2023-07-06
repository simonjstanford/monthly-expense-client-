// <copyright file="InvalidUserExpenseException.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using System.Runtime.Serialization;

namespace MonthlyExpenses.Api.Models;

[Serializable]
public class InvalidUserExpenseException : Exception
{
    public InvalidUserExpenseException()
    {
    }

    public InvalidUserExpenseException(string message)
        : base(message)
    {
    }

    protected InvalidUserExpenseException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}