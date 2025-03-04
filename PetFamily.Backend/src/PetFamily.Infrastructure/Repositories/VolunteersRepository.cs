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

        public async Task<Result<IEnumerable<Volunteer>>> GetAll(CancellationToken cancellationToken = default)
        {
            var collection = await _dbContext.Volunteers.Where(x => true).ToListAsync(cancellationToken); 
            return collection;
        }

        public async Task<Result<Volunteer, Error>> GetById(VolunteerId id, CancellationToken cancellationToken = default)
        {
            var volunteer = await _dbContext.Volunteers.FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
            if (volunteer is null)
                return Errors.General.NotFound(id);

            return volunteer;
        }

        public async Task<Result<Volunteer, Error>> GetByPhoneNumber(string phoneNumber, CancellationToken cancellationToken = default)
        {
            //нужен индекс по колонке с номером
            var volunteer = await _dbContext.Volunteers.FirstOrDefaultAsync(v => v.Info.PhoneNumber == phoneNumber, cancellationToken);

            if (volunteer is null)
                return Errors.Volunteers.NotFoundByPhoneNumber(phoneNumber);

            return volunteer;

        }

        public async Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default)
        {
            await _dbContext.Volunteers.AddAsync(volunteer, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return volunteer.Id;
        }



    }
}
