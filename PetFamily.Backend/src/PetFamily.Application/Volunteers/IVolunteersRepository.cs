using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer;

namespace PetFamily.Application.Repositories
{
    public interface IVolunteersRepository
    {
        Task<Guid> Add(Volunteer volunteer, CancellationToken cancellationToken = default);
        Task<Result<Volunteer, Error>> GetById(VolunteerId id, CancellationToken cancellationToken = default);
        Task<Result<IEnumerable<Volunteer>>> GetAll (CancellationToken cancellationToken = default);
        Task<Result<Volunteer, Error>> GetByPhoneNumber(string phoneNumber, CancellationToken cancellationToken = default);
    }
}