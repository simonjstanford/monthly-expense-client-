// <copyright file="EnumerableHelpers_SequenceEqual.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using FluentAssertions;
using MonthlyExpenses.Api.Utils;

namespace MonthlyExpenses.Api.Test.Utils;

public class EnumerableHelpers_SequenceEqual
{
    [Fact]
    public void SequenceEqual_WhenBothNull_ShouldReturnTrue()
    {
        string[] x = null!;
        string[] y = null!;
        var result = EnumerableHelpers.SequenceEqual(x, y);
        result.Should().BeTrue();
    }

    [Fact]
    public void SequenceEqual_WhenXNull_ShouldReturnTrue()
    {
        string[] x = null!;
        string[] y = new[] { "Test" };
        var result = EnumerableHelpers.SequenceEqual(x, y);
        result.Should().BeFalse();
    }

    [Fact]
    public void SequenceEqual_WhenYNull_ShouldReturnTrue()
    {
        string[] x = new[] { "Test" };
        string[] y = null!;
        var result = EnumerableHelpers.SequenceEqual(x, y);
        result.Should().BeFalse();
    }

    [Fact]
    public void SequenceEqual_WhenSameReference_ShouldReturnTrue()
    {
        string[] x = new[] { "Test" };
        string[] y = x;
        var result = EnumerableHelpers.SequenceEqual(x, y);
        result.Should().BeTrue();
    }

    [Fact]
    public void SequenceEqual_WhenSameValue_ShouldReturnTrue()
    {
        string[] x = new[] { "Test" };
        string[] y = new[] { "Test" };
        var result = EnumerableHelpers.SequenceEqual(x, y);
        result.Should().BeTrue();
    }

    [Fact]
    public void SequenceEqual_WhenDifferentValue_ShouldReturnFalse()
    {
        string[] x = new[] { "Test1" };
        string[] y = new[] { "Test2" };
        var result = EnumerableHelpers.SequenceEqual(x, y);
        result.Should().BeFalse();
    }

    [Fact]
    public void SequenceEqual_WhenDifferentSizes_ShouldReturnFalse()
    {
        string[] x = new[] { "Test1" };
        string[] y = new[] { "Test1", "Test2" };
        var result = EnumerableHelpers.SequenceEqual(x, y);
        result.Should().BeFalse();
    }
}
