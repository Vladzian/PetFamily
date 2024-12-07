using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PetFamily.Domain
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string ByName { get; set; } = null!;
        public string AnimalType { get; set; } = null!; //enum?
        public string Description { get; set; } = null!;
        public string Breed { get; set; } = null!;
        public string Color { get; set; } = null!;
        public string PetHealthInfo { get; set; } = null!;
        public IAddress Address { get; set; } = null!; //VO
        public float  Weight { get; set; }
        public float Height { get; set; }
        public string OwnerPhoneNumber { get; set; }
        public bool IsNeutered { get; set; }
        public Date DateOfBirth { get; set; }
        public bool IsVaccinated { get; set; }
        public HelpStatus HelpStatus { get; set; }
        public List<PropForHelp> PropsForHelp { get; set; }
        public Date CreationDate { get; set; }


    }

    public class PropForHelp
    {
    }

    public enum HelpStatus
    {
        NeedsHelp = 0,
        LookingForAHome = 1,
        FoundAHome = 2
    }

    public class PetAddress : IAddress
    {
    }

    public interface IAddress
    {
    }


}
