using CSharpFunctionalExtensions;
using PetFamily.Application.Repositories;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer;

namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public class CreateVolunteerHandler
    {
        private readonly IVolunteersRepository _volunteersRepository;
        public CreateVolunteerHandler(IVolunteersRepository volunteersRepository)
        {
            _volunteersRepository = volunteersRepository;
        }        

        public async Task<Result<Guid,Error>> HandleAsync(CreateVolunteerRequest request, CancellationToken cancellationToken = default)
        {
            //валидируем VO
            var volunteerId = VolunteerId.NewEntityId();
            var volunteerFullName = VolunteerFullName.Create(request.fullName);
            if (volunteerFullName.IsFailure)
                return volunteerFullName.Error;

            var volunteerInfo = VolunteerInfo.Create(request.email,request.generalDescription,request.phoneNumber,request.experience);
            if (volunteerInfo.IsFailure)
                return volunteerInfo.Error;

            //создаем доменную сущность
            var volunteer = Volunteer.Create(volunteerId, volunteerFullName.Value, volunteerInfo.Value);

            //вызываем сохранение в БД при помощи репозитория
            var guidVolunteer = await _volunteersRepository.Add(volunteer, cancellationToken);

            return guidVolunteer;
        }
    }
}
