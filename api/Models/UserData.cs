using System.Text.Json.Serialization;

namespace MonthlyExpenses.Api
{
    public class UserExpenses
    {

        [JsonPropertyName("user")]
        public string User { get; set; }

        [JsonPropertyName("months")]
        public MonthData[] Months { get; set; }
    }
}