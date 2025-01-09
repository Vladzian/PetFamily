using CSharpFunctionalExtensions;
using System.Text;
using System.Text.RegularExpressions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;

namespace PetFamily.Domain.Volunteer
{
    public class Pet : Shared.Entity<PetId>
    {
        //for ef core
        private Pet(PetId id) : base(id)
        {
        }

        private Pet(PetId petId, PetByName byName,
                    PetInfo info, PetSpecie specie, 
                    Address petAddress) : base(petId)
        {           
            ByName = byName;
            Info = info;
            Specie = specie;
            Address = petAddress;
            CreationDate = DateTime.UtcNow;
        }
          
        public PetByName ByName { get; private set; }
        public DateTime CreationDate { get; private set; }
        public PetSpecie Specie { get; private set; }              
        public PetInfo Info { get; private set; }
        public Address Address { get; private set; }
        public string PetAddressByString => Address.AddressByString(Address);
        public PetPhotos Photos {  get; private set; }
        public HelpRequisiteList? HelpRequisiteList { get; private set; }

        public static Result<Pet, Error> Create(PetId petId, PetByName byName, 
                                         PetInfo info, PetSpecie specie,  
                                         Address petAddress)
        {
            return new Pet(petId, byName, info, specie, petAddress);
        }

        /*public Result<IReadOnlyList<HelpRequisite>,Error> AddRequisiteForHelp(HelpRequisite helpRequisite)
        {
            if (_requisitesForHelp.Contains(helpRequisite))
                return Errors.General.ValueAlreadyExist(helpRequisite, nameof(RequisitesForHelp));

            _requisitesForHelp.Add(helpRequisite);
            return _requisitesForHelp;
        }*/
        public Result<IReadOnlyList<PetPhoto>, Error> AddPetPhoto(PetPhoto petPhoto)
        {
            return Photos.AddPetPhoto(petPhoto);
        }

    }   
}
