using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Extensions;
using PetFamily.API.Response;
using PetFamily.Application.Volunteers.CreateVolunteer;
using PetFamily.Application.Volunteers.GetVolunteer;

namespace PetFamily.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VolunteersController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] GetVolunteerHandler createVolunteerHandler,                                                
                                                CancellationToken cancellationToken = default)
        {
            var result = await createVolunteerHandler.GetAllAsync(cancellationToken);            

            return Ok(Envelope.Ok(result.Value));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromServices] GetVolunteerHandler createVolunteerHandler,
                                              Guid id,
                                              CancellationToken cancellationToken = default)
        {
            var result = await createVolunteerHandler.GetById(id, cancellationToken);
            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(Envelope.Ok(result.Value));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromServices] CreateVolunteerHandler createVolunteerHandler,
                                                [FromBody] CreateVolunteerCommand request,
                                                CancellationToken cancellationToken = default)
        {
            var result = await createVolunteerHandler.HandleAsync(request, cancellationToken);
            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(Envelope.Ok(result.Value));
        }    

    }
}
