// <copyright file="Serializer.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System.Text.Json;

namespace MonthlyExpenses.Api.Utils;

public static class Serializer
{
    public static string Serialize<T>(T obj) => JsonSerializer.Serialize<T>(obj, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

    public static T Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
}
