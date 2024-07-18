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
        catch (SpieltagAlreadyExistsException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = 409;

            var problemDetails = new ProblemDetails()
            {
                Status = 409,
                Detail = "",
                Instance = "",
                Title = "Spieltag existiert bereits !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (SpieltagNotFoundException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Detail = "",
                Instance = "",
                Title = "Spieltag nicht gefunden !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (SpieltagInUseException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = 409;

            var problemDetails = new ProblemDetails()
            {
                Status = 409,
                Detail = "",
                Instance = "",
                Title = "Spieltag in Verwendung !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (NeunerRattenAlreadyExistsException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = 409;

            var problemDetails = new ProblemDetails()
            {
                Status = 409,
                Detail = "",
                Instance = "",
                Title = "9er/Ratten Eintrag existiert bereits !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (NeunerRattenNotFoundException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Detail = "",
                Instance = "",
                Title = "9er/Ratten Eintrag nicht gefunden !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (Spiel6TageRennenAlreadyExistsException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = 409;

            var problemDetails = new ProblemDetails()
            {
                Status = 409,
                Detail = "",
                Instance = "",
                Title = "Spiel6TageRennen Eintrag existiert bereits !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (Spiel6TageRennenNotFoundException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Detail = "",
                Instance = "",
                Title = "Spiel6TageRennen Eintrag nicht gefunden !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (SpielBlitztunierAlreadyExistsException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = 409;

            var problemDetails = new ProblemDetails()
            {
                Status = 409,
                Detail = "",
                Instance = "",
                Title = "SpielBlitztunier Eintrag existiert bereits !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (SpielBlitztunierNotFoundException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Detail = "",
                Instance = "",
                Title = "SpielBlitztunier Eintrag nicht gefunden !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (SpielMeisterschaftAlreadyExistsException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = 409;

            var problemDetails = new ProblemDetails()
            {
                Status = 409,
                Detail = "",
                Instance = "",
                Title = "SpielMeisterschaft Eintrag existiert bereits !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (SpielMeisterschaftNotFoundException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Detail = "",
                Instance = "",
                Title = "SpielMeisterschaft Eintrag nicht gefunden !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (SpielKombimeisterschaftAlreadyExistsException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = 409;

            var problemDetails = new ProblemDetails()
            {
                Status = 409,
                Detail = "",
                Instance = "",
                Title = "SpielKombimeisterschaft Eintrag existiert bereits !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (SpielKombimeisterschaftNotFoundException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Detail = "",
                Instance = "",
                Title = "SpielKombimeisterschaft Eintrag nicht gefunden !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (SpielPokalAlreadyExistsException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = 409;

            var problemDetails = new ProblemDetails()
            {
                Status = 409,
                Detail = "",
                Instance = "",
                Title = "SpielPokal Eintrag existiert bereits !",
                Type = ""
            };

            var problemDetailsJson = JsonConvert.SerializeObject(problemDetails);
            await context.Response.WriteAsync(problemDetailsJson);
        }
        catch (SpielPokalNotFoundException)
        {
            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = StatusCodes.Status404NotFound;

            var problemDetails = new ProblemDetails()
            {
                Status = StatusCodes.Status404NotFound,
                Detail = "",
                Instance = "",
                Title = "SpielPokal Eintrag nicht gefunden !",
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
