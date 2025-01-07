using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using System.Text;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Volunteer
{
    public class Volunteer : Shared.Entity<VolunteerId>
    {   
        //for ef core
        private Volunteer(VolunteerId id) : base(id)
        {            
        }
        public Volunteer(VolunteerId volunteerId, VolunteerFullName fullName, VolunteerInfo volunteerInfo) : base(volunteerId)
        {      
            FullName = fullName;
            Info = volunteerInfo;
            ListSocialMedia = SocialMediaList.Create();
            ListHelpRequisite = HelpRequisiteList.Create();
        }
        public VolunteerFullName FullName { get; private set; }

        public VolunteerInfo Info { get; private set; }

        public SocialMediaList? ListSocialMedia { get; private set; }

        public HelpRequisiteList? ListHelpRequisite { get; private set; }

        private readonly List<Pet> _Pets = [];
        public IReadOnlyList<Pet> Pets => _Pets;

        public ushort CountPets(HelpStatus status)
        {
            return (ushort)_Pets.Count;
        }
        public ushort CountPetsByStatus(HelpStatus status) 
        {            
            return (ushort)_Pets.Count(p => p.Info.HelpStatus == status); 
        }
        public ushort CountPetsFoundAHome() 
        {
            return CountPetsByStatus(HelpStatus.FoundAHome);
        }
        public ushort CountPetsLookingForAHome()
        {
            return CountPetsByStatus(HelpStatus.LookingForAHome);
        }
        public ushort CountPetsNeedsHelp()
        {
            return CountPetsByStatus(HelpStatus.NeedsHelp);
        }

        public Result<IReadOnlyList<Pet>> AddPet(Pet pet)
        {
            if (_Pets.Contains(pet))
                return Result.Failure<IReadOnlyList<Pet>>("Этот питомец уже добавлен в коллекцию волонтера");

            _Pets.Add(pet);
            return Result.Success(Pets);
        }
        //public Result<IReadOnlyList<HelpRequisite>, Error> AddRequisiteForHelp(HelpRequisite helpRequisite)
        //{
        //    if (_requisitesForHelp.Contains(helpRequisite))
        //        return Errors.General.ValueAlreadyExist(helpRequisite, nameof(RequisitesForHelp));

        //    _requisitesForHelp.Add(helpRequisite);
        //    return _requisitesForHelp;
        //}

        //public Result<IReadOnlyList<SocialMedia> , Error> AddSocialMedia(SocialMedia socialMedia)
        //{

        //    if (_socialMedias.Contains(socialMedia))
        //        return Errors.General.ValueAlreadyExist(socialMedia, nameof(SocialMediaList));

        //    _socialMedias.Add(socialMedia);
        //    return _socialMedias;
        //}

        public static Volunteer Create(VolunteerId volunteerId, VolunteerFullName fullName, VolunteerInfo volunteerInfo)
        {
            return new Volunteer(volunteerId, fullName, volunteerInfo);
        }
    }
}
