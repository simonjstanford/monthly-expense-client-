using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MonthlyExpenses.Api.Models
{
    public class MonthData
    {
        [JsonPropertyName("monthStart")]
        public DateTime MonthStart { get; set; }

        [JsonPropertyName("income")]
        public Dictionary<string, decimal> Income { get; set; }

        [JsonPropertyName("outgoings")]
        public Dictionary<string, decimal> Outgoings { get; set; }
    }
}