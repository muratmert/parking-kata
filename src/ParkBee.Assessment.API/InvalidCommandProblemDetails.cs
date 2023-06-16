using Microsoft.AspNetCore.Http;
using ParkBee.Assessment.Application.Configuration.Validation;

namespace ParkBee.Assessment.API
{
    public class InvalidCommandProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public InvalidCommandProblemDetails(InvalidCommandException exception)
        {
            Title = exception.Message;
            Status = StatusCodes.Status400BadRequest;
            Detail = exception.Details;
            Type = "https://validation-error";
        }
    }
}