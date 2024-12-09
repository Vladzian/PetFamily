using System.Text;
using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Pets
{
    public class Pet : Shared.Entity<PetId>
    {
        //for ef core
        private Pet(PetId petId) : base(petId)
        {
        }

        private Pet(PetId petId, string byName, 
                    string description, Species specie,
                    string breedName, DateTime dateOfBirth,
                    string color, string petHealthInfo,
                    float weight, float height,
                    bool isNeutered, bool isVaccinated,
                    HelpStatus helpStatus, Address petAddress,
                    string ownerPhoneNumber) : base(petId)
        {
            ByName = byName;
            Description = description;
            Specie = specie;
            BreedName = breedName;
            DateOfBirth = dateOfBirth;
            Color = color;
            PetHealthInfo = petHealthInfo;
            Weight = weight;
            Height = height;
            IsNeutered = isNeutered;
            IsVaccinated = isVaccinated;
            HelpStatus = helpStatus;
            PetAddress = petAddress;
            OwnerPhoneNumber = ownerPhoneNumber;

            CreationDate = DateTime.UtcNow;
        }

        public string ByName { get; private set;}
        public string Description { get; private set;} = String.Empty;
        public DateTime DateOfBirth { get; private set;} = default!;
        public Species Specie { get; private set; } 
        public string BreedName { get; private set; } 
        public string Color { get; private set;} = null!;
        public string PetHealthInfo { get; private set;} = String.Empty;
        public float Weight { get; private set;} 
        public float Height { get; private set;}
        public bool IsNeutered { get; private set; }
        public bool IsVaccinated { get; private set; } 
        public HelpStatus HelpStatus { get; private set; } = HelpStatus.FoundAHome;
        public Address PetAddress { get; private set; }
        public string PetAddressByString => Address.AddressByString(PetAddress);
        public string OwnerPhoneNumber { get; private set; }

        private readonly List<RequisiteForHelp> _RequisitesForHelp = [];
        public IReadOnlyList<RequisiteForHelp> RequisitesForHelp => _RequisitesForHelp;
        public DateTime CreationDate { get; private set; }

        public static Result<Pet> Create(PetId petId, string byName,
                                        string description, Species species,
                                        string breedName, DateTime dateOfBirth,
                                        string color, string petHealthInfo,
                                        float weight, float height,
                                        bool isNeutered, bool isVaccinated, 
                                        HelpStatus helpStatus, Address petAddress,
                                        string ownerPhoneNumber)
        {
            bool ValidationFailed = false;
            StringBuilder stringBuilder = new StringBuilder();
            string FailureDescription = String.Empty;
            if (string.IsNullOrWhiteSpace(byName))
            {
                ValidationFailed = true;
                stringBuilder.AppendLine("Не указана кличка животного.");
            }

            if (string.IsNullOrWhiteSpace(color))//пусть будет обязательным полем
            {
                ValidationFailed = true;
                stringBuilder.AppendLine("Не указан окрас животного.");
            }
            if (string.IsNullOrWhiteSpace(petHealthInfo)) //считаю обязательным полем
            {
                ValidationFailed = true;
                stringBuilder.AppendLine("Не указана информация о состоянии здоровья животного.");
            }
            //честно найдено в интернете (https://habr.com/ru/articles/110731/) - не проверял
            Regex regex = new Regex(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$");
            if (!regex.IsMatch(ownerPhoneNumber))
            {
                ValidationFailed = true;
                stringBuilder.AppendLine("Некорректно указан номер для связи с владельцем.");
            }

            if (ValidationFailed)
            {
                FailureDescription = stringBuilder.ToString();
                return Result.Failure<Pet>($"Необходимо исправить следующие замечания:\r\n ${FailureDescription}");
            }

            var pet = new Pet(petId, byName, description, species, breedName, dateOfBirth, 
                              color, petHealthInfo, weight, height, 
                              isNeutered, isVaccinated, helpStatus, petAddress, 
                              ownerPhoneNumber);
            return Result.Success(pet);
        }

        public Result<IReadOnlyList<RequisiteForHelp>> AddRequisiteForHelp(RequisiteForHelp _requisiteForHelp)
        {
            if (_RequisitesForHelp.Contains(_requisiteForHelp))
                return Result.Failure<IReadOnlyList<RequisiteForHelp>>("This requisite already exists");

            _RequisitesForHelp.Add(_requisiteForHelp);
            return Result.Success(RequisitesForHelp);
        }
    }

   
    public enum HelpStatus //пока перечисление, но статусы могут меняться, стоит их завести как отдельную сущность в БД
    {
        NeedsHelp = 0,
        LookingForAHome = 1,
        FoundAHome = 2
    }
    public enum Species
    {
        Dog,
        Cat,
        Ower
    }
}
