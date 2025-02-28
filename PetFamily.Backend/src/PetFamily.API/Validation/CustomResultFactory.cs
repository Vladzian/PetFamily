using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Results;
using CSharpFunctionalExtensions;
using PetFamily.API.Response;
using PetFamily.Domain.Shared;

namespace PetFamily.API.Validation
{
    public class CustomResultFactory : IFluentValidationAutoValidationResultFactory
    {
        public IActionResult CreateActionResult(
                ActionExecutingContext context, 
                ValidationProblemDetails? validationProblemDetails)
        {
            if(validationProblemDetails is null)
            {
                throw new InvalidProgramException("validationProblemDetails is null");
            }
            List<ResponseError> errors = [];

            foreach(var (invalidField, validationErrors) in validationProblemDetails.Errors)
            {

                var respErrors = from errorMessage in validationErrors
                             let error = Error.Deserialize(errorMessage)
                             select new ResponseError(error.Code, error.Message, invalidField);

                errors.AddRange(respErrors);                
            }
            var envelope  = Envelope.Error(errors);
            
            return new ObjectResult(envelope)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }
    }
}
