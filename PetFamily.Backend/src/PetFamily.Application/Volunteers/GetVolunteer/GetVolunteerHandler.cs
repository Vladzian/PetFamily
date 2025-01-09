using CSharpFunctionalExtensions;
using PetFamily.Application.Repositories;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Application.Volunteers.GetVolunteer
{
    public class GetVolunteerHandler
    {
        private readonly IVolunteersRepository _volunteersRepository;

        public GetVolunteerHandler(IVolunteersRepository volunteersRepository)
        {
            _volunteersRepository = volunteersRepository;
        }
        public async Task<Result<IEnumerable<Volunteer>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _volunteersRepository.GetAll(cancellationToken);
        }

        public async Task<Result<Volunteer, Error>> GetById(Guid request, CancellationToken cancellationToken = default)
        {
            return await _volunteersRepository.GetById(request,cancellationToken);
        }
    }

}
