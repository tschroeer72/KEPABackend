using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FluentValidation;
using KEPABackend.Exceptions;

namespace KEPABackend;

/// <summary>
/// Exception Middleware
/// </summary>
public class ExceptionMiddleware
{
    private RequestDelegate Next { get; }

    /// <summary>
    /// Construtor
    /// </summary>
    /// <param name="next"></param>
    public ExceptionMiddleware(RequestDelegate next)
    {
        Next = next;
    }

    /// <summary>
    /// Invoke
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
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
        catch (MeisterschaftstypNotFoundException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Detail = "",
                Instance = "",
                Title = "Meisterschaftstyp nicht gefunden !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (MeisterschaftNotFoundException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Detail = "",
                Instance = "",
                Title = "Meisterschaft nicht gefunden !",
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
