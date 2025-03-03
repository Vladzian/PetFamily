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
        public async Task<Result<Guid, Error>> HandleAsync(CreateVolunteerCommand request, CancellationToken cancellationToken = default)
        {
            var volunteerId = VolunteerId.NewEntityId();
            var volunteerFullName = VolunteerFullName.Create(request.FullName).Value;

            var volunteerInfo = VolunteerInfo.Create(request.Info.Email,
                                                     request.Info.GeneralDescription,
                                                     request.Info.PhoneNumber,
                                                     request.Info.Experience).Value;

            //проверим наличие волонтера с таким же номером телефона
            var volunteer = await _volunteersRepository.GetByPhoneNumber(request.Info.PhoneNumber, cancellationToken);
            if (volunteer.IsSuccess)
                return Errors.Volunteers.AlreadyExist();


            //создаем доменную сущность
            var newVolunteer = Volunteer.Create(volunteerId, volunteerFullName, volunteerInfo);

            if (request.SocialMedias.Count > 0)
            {
                List<SocialMedia> tmpSocMedias = [];

                foreach (var socialMedia in request.SocialMedias)
                {
                    var result = SocialMedia.Create(socialMedia.Name, socialMedia.Link);
                    tmpSocMedias.Add(result.Value);
                }
                SocialMediaList listSocMedias = new SocialMediaList(tmpSocMedias);
                newVolunteer.SetSocialMedia(listSocMedias);
            }

            if (request.HelpRequisites.Count > 0)
            {
                List<HelpRequisite> tmpHelpRequisites = [];
                foreach (var helpRequisite in request.HelpRequisites)
                {
                    var result = HelpRequisite.Create(helpRequisite.Name, helpRequisite.Desc);
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
