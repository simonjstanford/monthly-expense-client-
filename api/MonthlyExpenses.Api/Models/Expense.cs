// <copyright file="Expense.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using System.Text.Json.Serialization;

namespace MonthlyExpenses.Api.Models;

public sealed class Expense : IEquatable<Expense>
{
    public Expense(string name, decimal value)
    {
        Name = name;
        Value = value;
    }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("value")]
    public decimal Value { get; set; }

    public static bool operator ==(Expense expense1, Expense expense2)
    {
        if (((object)expense1) == null || ((object)expense2) == null)
        {
            return Equals(expense1, expense2);
        }

        return expense1.Equals(expense2);
    }

    public static bool operator !=(Expense expense1, Expense expense2) => !(expense1 == expense2);

    public bool Equals(Expense other)
    {
        if (other == null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (Equals(Name, other.Name) && Equals(Value, other.Value))
        {
            return true;
        }

        return false;
    }

    public override bool Equals(object obj) => Equals(obj as Expense);

    public override int GetHashCode() => HashCode.Combine(Name, Value);
}
