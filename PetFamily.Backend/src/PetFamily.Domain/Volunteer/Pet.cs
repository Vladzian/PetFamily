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
        public PetPhotos Photos {  get; }
        public Requisites RequisitesForHelp { get; }

        public static Result<Pet, Error> Create(PetId petId, PetByName byName, 
                                         PetInfo info, PetSpecie? specie,  
                                         Address petAddress)
        {
            PetSpecie speciePet;
            if (specie is null)
                speciePet = PetSpecie.Empty();
            else
                speciePet = specie;

            return new Pet(petId, byName, info, speciePet, petAddress);
        }

        public Result<IReadOnlyList<HelpRequisite>,Error> AddRequisiteForHelp(HelpRequisite _requisiteForHelp)
        {
            return RequisitesForHelp.AddHelpRequisite(_requisiteForHelp);
        }
        public Result<IReadOnlyList<PetPhoto>, Error> AddPetPhoto(PetPhoto petPhoto)
        {
            return Photos.AddPetPhoto(petPhoto);
        }

    }   
}
