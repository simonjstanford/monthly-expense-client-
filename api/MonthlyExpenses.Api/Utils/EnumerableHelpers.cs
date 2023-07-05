// <copyright file="EnumerableHelpers.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

namespace MonthlyExpenses.Api.Utils;

public static class EnumerableHelpers
{
    public static bool SequenceEqual<T>(IEnumerable<T> values1, IEnumerable<T> values2)
    {
        if (ReferenceEquals(values1, values2))
        {
            return true;
        }

        if (values1 is null || values2 is null)
        {
            return false;
        }

        return values1.SequenceEqual(values2);
    }
}
