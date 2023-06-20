using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace MonthlyExpenses.Api
{
    public static class UserExpensesFunction
    {
        [FunctionName("monthexpenses")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // string name = req.Query["name"];

            // string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // dynamic data = JsonConvert.DeserializeObject(requestBody);
            // name = name ?? data?.name;

            // string responseMessage = string.IsNullOrEmpty(name)
            //     ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //     : $"Hello, {name}. This HTTP triggered function executed successfully.";

            var data = new UserExpenses
            {
                User = "Test User!",
                Months = new []
                {
                    new MonthData
                    {
                        MonthStart = new DateTime(2023, 6, 1),
                        Income = new Dictionary<string, decimal>
                        {
                            { "Salary", 2000 },
                            { "Overtime", 200 },
                        },
                        Outgoings = new Dictionary<string, decimal>
                        {
                            { "Rent", 500 },
                            { "Car", 100 },
                            { "Phone", 30 },
                            { "Internet", 40 },
                            { "Food", 300 },
                        }
                    }
                }
            };

            return new JsonResult(data);
        }
    }
}
