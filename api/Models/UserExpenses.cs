using System.Text.Json.Serialization;

namespace MonthlyExpenses.Api.Models
{
    public class UserExpenses
    {
        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("months")]
        public MonthData[] Months { get; set; }
    }
}