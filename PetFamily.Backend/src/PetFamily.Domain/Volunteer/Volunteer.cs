using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PetFamily.Domain.Volunteer
{
    public class Volunteer : Shared.Entity<VolunteerId>
    {
        //for ef core
        public Volunteer(VolunteerId petId) : base(petId)
        {
        }
        public string FullName { get; private set; }
        public string Email { get; private set; }    
        public string GeneralDescription { get; private set; }
        public string PhoneNumber { get; private set; }
        public byte Experience { get; private set; }


        private readonly List<SocialMedia> _SocialMedias = [];
        public IReadOnlyList<SocialMedia> SocialMedias => _SocialMedias;

        private readonly List<RequisiteForHelp> _RequisitesForHelp = [];
        public IReadOnlyList<RequisiteForHelp> RequisitesForHelp => _RequisitesForHelp;

        private readonly List<Pet> _Pets = [];
        public IReadOnlyList<Pet> Pets => _Pets;

        public ushort CountPetsByStatus(HelpStatus status) 
        {            
            return (ushort)_Pets.Count(p => p.HelpStatus == status); 
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
    }

    public class SocialMedia
    {
        public SocialMedia(string name, string link)
        {
            Name = name;
            Link = link;
        }
        public string Name { get; private set; }
        public string Link { get; private set; }
    }
}
