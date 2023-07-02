// <copyright file="PostUserExpensesFunction.cs" company="Simon Stanford">
// Copyright (c) Simon Stanford. All rights reserved.
// </copyright>

using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using MonthlyExpenses.Api.Interfaces;
using MonthlyExpenses.Api.Models;

namespace MonthlyExpenses.Api.Functions;

public class PostUserExpensesFunction
{
    private readonly IRepository repository;
    private readonly IAuthenticator authenticator;

    public PostUserExpensesFunction(IRepository repository, IAuthenticator authenticator)
    {
        this.repository = repository;
        this.authenticator = authenticator;
    }

    [FunctionName("PostUserExpenses")]
    [OpenApiOperation(operationId: "PostUserExpenses", tags: new string[0], Description = "Sets the expense data for the currently authenticated user")]
    [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/json", bodyType: typeof(UserExpenses), Description = "The data has been set")]
    [OpenApiResponseWithoutBody(HttpStatusCode.Unauthorized, Description = "When not authenticated")]
    [OpenApiResponseWithoutBody(HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> PostUserExpenses(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "user/data")] HttpRequest req,
        ILogger log)
    {
        try
        {
            log.LogInformation("monthexpenses POST called");
            var data = await GetUserExpense(req);
            var user = await authenticator.AuthenticateRequest(req, log);
            await repository.SaveUserExpenses(user, data, log);

            if (data != null)
            {
                log.LogInformation("monthexpenses POST completed");
                return new JsonResult(data);
            }
            else
            {
                return new NotFoundResult();
            }
        }
        catch (ClientAuthenticationException ex)
        {
            log.LogError(ex.Message);
            return new UnauthorizedResult();
        }
        catch (Exception ex)
        {
            log.LogError(ex.Message);
            return new InternalServerErrorResult();
        }
    }

    private static async Task<UserExpenses> GetUserExpense(HttpRequest req)
    {
        if (req.Body == null || !req.IsJsonContentType())
        {
            throw new Exception("Content type is not JSON");
        }

        using var streamReader = new StreamReader(req.Body);
        var body = await streamReader.ReadToEndAsync();
        return JsonSerializer.Deserialize<UserExpenses>(body);
    }
}
