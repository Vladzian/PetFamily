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

            if(request.socialMedias.Count > 0)
            {
                List<SocialMedia> tmpSocMedias= [];

                foreach (var socialMedia in request.socialMedias)
                {
                    var result = SocialMedia.Create(socialMedia.name, socialMedia.link);
                    if(result.IsFailure)
                        return result.Error;

                    tmpSocMedias.Add(result.Value);
                }
                SocialMediaList listSocMedias = new SocialMediaList(tmpSocMedias);
                newVolunteer.SetSocialMedia(listSocMedias);
            }

            if (request.helpRequisites.Count > 0)
            {
                List<HelpRequisite> tmpHelpRequisites = [];
                foreach ( var helpRequisite in request.helpRequisites)
                {
                    var result = HelpRequisite.Create(helpRequisite.name, helpRequisite.desc);
                    if (result.IsFailure)
                        return result.Error;

                    tmpHelpRequisites.Add(result.Value);
                }
                HelpRequisiteList listHelpRequisite = new HelpRequisiteList(tmpHelpRequisites);
                newVolunteer.SetRequisiteForHelp(listHelpRequisite);
            }

            //вызываем сохранение в БД при помощи репозитория
            var guidVolunteer = await _volunteersRepository.Add(newVolunteer, cancellationToken);
            return guidVolunteer;
        }
    }
}
