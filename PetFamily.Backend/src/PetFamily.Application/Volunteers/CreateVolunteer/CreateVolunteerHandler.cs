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
        public async Task<Result<Guid,Error>> HandleAsync(CreateVolunteerCommand request, CancellationToken cancellationToken = default)
        {
            //валидируем VO
            var volunteerId = VolunteerId.NewEntityId();
            var volunteerFullName = VolunteerFullName.Create(request.fullName);
            if (volunteerFullName.IsFailure)
                return volunteerFullName.Error;

            var volunteerInfo = VolunteerInfo.Create(request.email,request.generalDescription,request.phoneNumber,request.experience);
            if (volunteerInfo.IsFailure)
                return volunteerInfo.Error;

            //проверим наличие волонтера с таким же номером телефона
            var volunteer = await _volunteersRepository.GetByPhoneNumber(request.phoneNumber, cancellationToken);
            if (volunteer.IsSuccess)
                return Errors.Volunteers.AlreadyExist();


            //создаем доменную сущность
            var newVolunteer = Volunteer.Create(volunteerId, volunteerFullName.Value, volunteerInfo.Value);

            /*if(request.socialMedias.Count > 0)
            {
                foreach (var socialMedia in request.socialMedias)
                {
                    SocialMedia.
                    var result = newVolunteer.AddSocialMedia(new SocialMedia(socialMedia.name, socialMedia.link));
                    if (result.IsFailure)
                        return result.Error;
                }               
            }

            if (request.helpRequisites.Count > 0)
            {
                foreach ( var helpRequisite in request.helpRequisites)
                {
                    var result = newVolunteer.AddRequisiteForHelp(new HelpRequisite(helpRequisite.name, helpRequisite.desc));
                    if (result.IsFailure)
                        return result.Error;
                }
            }*/

            //вызываем сохранение в БД при помощи репозитория
            var guidVolunteer = await _volunteersRepository.Add(newVolunteer, cancellationToken);
            return guidVolunteer;
        }
    }
}
