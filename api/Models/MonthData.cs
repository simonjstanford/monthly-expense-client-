// <copyright file="MonthData.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MonthlyExpenses.Api.Models
{
    public class MonthData
    {
        /// <summary>
        /// The month that this expense info represents.
        /// </summary>
        [JsonPropertyName("monthStart")]
        public DateTime MonthStart { get; set; }

        /// <summary>
        /// The income that is being received this month.
        /// </summary>
        [JsonPropertyName("income")]
        public Dictionary<string, decimal> Income { get; set; }

        /// <summary>
        /// The outgoings that are paid out this month.
        /// </summary>
        [JsonPropertyName("outgoings")]
        public Dictionary<string, decimal> Outgoings { get; set; }
    }
}