// <copyright file="Serializer.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System.Text.Json;

namespace MonthlyExpenses.Api.Utils;

public static class Serializer
{
    public static string Serialize<T>(T obj)
    {
        var serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        return JsonSerializer.Serialize<T>(obj, serializeOptions);
    }

    public static T Deserialize<T>(string json)
    {
        var serializeOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        return JsonSerializer.Deserialize<T>(json, serializeOptions);
    }
}
