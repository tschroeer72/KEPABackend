using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FluentValidation;
using KEPABackend.Exceptions;

namespace KEPABackend;

public class ExceptionMiddleware
{
    private RequestDelegate Next { get; }

    public ExceptionMiddleware(RequestDelegate next)
    {
        Next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await Next(context);
        }
        catch (MitgliedNotFoundException ex)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Detail = ex.Message,
                Instance = "",
                Title = "Mitglied nicht gefunden !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (ValidationException ex)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status400BadRequest,
                Detail = JsonConvert.SerializeObject(ex.Errors),
                Instance = "",
                Title = "Validation Error",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status500InternalServerError,
                Detail = ex.Message,
                Instance = "",
                Title = "Internal Server Error - something went wrong",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
    }
}
