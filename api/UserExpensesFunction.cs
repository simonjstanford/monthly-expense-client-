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
            
            var principal = await authenticator.GetClaimsPrincipal(req, log);
            if (!principal.Identity.IsAuthenticated || !principal.IsInRole("authenticated"))
            {
                log.LogError($"Principal {principal.Identity.Name} is not authorised: {principal.Identity.IsAuthenticated}, {principal.IsInRole("authenticated")}");
                return new UnauthorizedResult();
            }

            log.LogInformation($"Principal {principal.Identity.Name} is authorised for monthexpenses GET");
            var data = await repository.GetUserExpenses();
            return new JsonResult(data);
        }
    }
}
