using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Extensions;
using PetFamily.Application.Volunteers.CreateVolunteer;

namespace PetFamily.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VolunteersController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromServices] CreateVolunteerHandler createVolunteerHandler,
                                                [FromBody] CreateVolunteerRequest request,
                                                CancellationToken cancellationToken = default)
        {
            var result = await createVolunteerHandler.HandleAsync(request, cancellationToken);
            if (result.IsFailure)
                return result.Error.ToResponse();

            return Ok(result.Value);
        }

    }
}
