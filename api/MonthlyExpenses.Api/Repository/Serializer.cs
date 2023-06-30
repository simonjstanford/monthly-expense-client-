// <copyright file="Serializer.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System.Text;
using System.Text.Json;

namespace MonthlyExpenses.Api.Repository;

public static class Serializer
{
    public static byte[] ObjectToByteArray<T>(T obj)
    {
        var json = JsonSerializer.Serialize(obj);
        return Encoding.UTF8.GetBytes(json);
    }

    public static T ByteArrayToObject<T>(byte[] bytes)
    {
        var json = Encoding.UTF8.GetString(bytes);
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}
