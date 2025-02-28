using FluentValidation;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Extensions;
using PetFamily.API.Response;
using PetFamily.Application.Volunteers.CreateVolunteer;
using PetFamily.Application.Volunteers.GetVolunteer;
using PetFamily.Domain.Shared;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PetFamily.API.Controllers
{    
    public class VolunteersController : ApplicationController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] GetVolunteerHandler createVolunteerHandler,                                                
                                                CancellationToken cancellationToken = default)
        {
            var result = await createVolunteerHandler.GetAllAsync(cancellationToken);            

            return Ok(result.Value);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromServices] GetVolunteerHandler createVolunteerHandler,
                                              Guid id,
                                              CancellationToken cancellationToken = default)
        {
            var result = await createVolunteerHandler.GetById(id, cancellationToken);
            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromServices] CreateVolunteerHandler createVolunteerHandler,
                                                //[FromServices] IValidator<CreateVolunteerCommand> validator,
                                                [FromBody] CreateVolunteerCommand request,
                                                CancellationToken cancellationToken = default)
        {
            //валидируем VO
            /*var validatorResult = await validator.ValidateAsync(request, cancellationToken);

            if(validatorResult.IsValid == false)
            {
                return validatorResult.ToValidationErrorResponse();
            }
            */
            var result = await createVolunteerHandler.HandleAsync(request, cancellationToken);
            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(result.Value);
        }    

    }
}
