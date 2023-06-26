// <copyright file="UserExpenses.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace MonthlyExpenses.Api.Models
{
    /// <summary>
    /// Stores all a user's expense data.
    /// </summary>
    public class UserExpenses
    {
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
    }
}