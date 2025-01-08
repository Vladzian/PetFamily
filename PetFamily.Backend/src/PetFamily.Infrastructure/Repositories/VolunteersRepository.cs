using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PetFamily.Application.Repositories;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer;

namespace PetFamily.Infrastructure.Repositories
{
    public class VolunteersRepository : IVolunteersRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public VolunteersRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default)
        {
            await _dbContext.Volunteers.AddAsync(volunteer, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return volunteer.Id;
        }

        public async Task<Result<Volunteer, Error>> GetById(VolunteerId id, CancellationToken cancellationToken = default)
        {
            var volunteer = await _dbContext.Volunteers
                                            .Include(v => v.Pets)
                                            .ThenInclude(p => p.Photos)
                                            .FirstOrDefaultAsync(v => v.Id == id, cancellationToken);

            if (volunteer is null)
                return Errors.General.NotFound(id);

            return volunteer;

        }
    }
}
