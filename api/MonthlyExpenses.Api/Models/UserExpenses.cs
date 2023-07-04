// <copyright file="UserExpenses.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Text.Json.Serialization;

namespace MonthlyExpenses.Api.Models;

/// <summary>
/// Stores all a user's expense data.
/// </summary>
public sealed class UserExpenses : IEquatable<UserExpenses>
{
    public UserExpenses()
        : this(string.Empty, Array.Empty<MonthData>())
    {
    }

    public UserExpenses(string user)
        : this(user, Array.Empty<MonthData>())
    {
    }

    public UserExpenses(string user, MonthData[] months)
    {
        User = user;
        Months = months;
    }

    /// <summary>
    /// The readable name of the user.
    /// </summary>
    [JsonPropertyName("user")]
    public string User { get; set; }

    /// <summary>
    /// The month by month income and outgoings of the user.
    /// </summary>
    [JsonPropertyName("months")]
    public MonthData[] Months { get; set; }

    public static bool operator ==(UserExpenses expense1, UserExpenses expense2)
    {
        if (((object)expense1) == null || ((object)expense2) == null)
        {
            return Equals(expense1, expense2);
        }

        return expense1.Equals(expense2);
    }

    public static bool operator !=(UserExpenses expense1, UserExpenses expense2) => !(expense1 == expense2);

    public bool Equals(UserExpenses other)
    {
        if (other == null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (Equals(User, other.User) && Months?.SequenceEqual(other.Months) == true)
        {
            return true;
        }

        return false;
    }

    public override bool Equals(object obj) => Equals(obj as UserExpenses);

    public override int GetHashCode()
    {
        var hash = default(HashCode);
        hash.Add(User);

        foreach (var month in Months)
        {
            hash.Add(month);
        }

        return hash.ToHashCode();
    }
}