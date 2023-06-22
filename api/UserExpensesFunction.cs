using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MonthlyExpenses.Api.Interfaces;

namespace MonthlyExpenses.Api
{
    public class UserExpensesFunction
    {
        private readonly IRepository repository;
        private readonly IAuthenticator authenticator;

        public UserExpensesFunction(IRepository repository, IAuthenticator authenticator)
        {
            this.repository = repository;
            this.authenticator = authenticator;
        }

        [FunctionName("monthexpenses")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("monthexpenses GET called");
            
            var (user, isAuthenticated) = await authenticator.AuthenticateRequest(req, log);
            if (!isAuthenticated)
            {
                return new UnauthorizedResult();
            }

            var data = await repository.GetUserExpenses(user);

            log.LogInformation("monthexpenses GET completed");
            return new JsonResult(data);
        }
    }
}
