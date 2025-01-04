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

        private Pet(PetId petId, string byName,
                    string description, DateTime dateOfBirth,
                    string color, string petHealthInfo,
                    float weight, float height,
                    bool isNeutered, bool isVaccinated,
                    HelpStatus helpStatus, Address petAddress,
                    string ownerPhoneNumber) : base(petId)
        {           
            ByName = byName;
            Description = description;            
            DateOfBirth = dateOfBirth;
            Color = color;
            PetHealthInfo = petHealthInfo;
            Weight = weight;
            Height = height;
            IsNeutered = isNeutered;
            IsVaccinated = isVaccinated;
            HelpStatus = helpStatus;
            Address = petAddress;
            OwnerPhoneNumber = ownerPhoneNumber;

            CreationDate = DateTime.UtcNow;
        }
          
        public string ByName { get; private set; }
        public string Description { get; private set; } = string.Empty;
        public DateTime DateOfBirth { get; private set; } = default!;
        public Guid? SpecieId {  get; } 
        public Guid? BreedId {  get; }        
        public string Color { get; private set; } = null!;
        public string PetHealthInfo { get; private set; } = string.Empty;
        public float Weight { get; private set; }
        public float Height { get; private set; }
        public bool IsNeutered { get; private set; }
        public bool IsVaccinated { get; private set; }
        public HelpStatus HelpStatus { get; private set; }
        public Address Address { get; private set; }
        public string PetAddressByString => Address.AddressByString(Address);
        public string OwnerPhoneNumber { get; private set; }
        public PetPhotos Photos {  get; }
        public Requisites RequisitesForHelp { get; }
        public DateTime CreationDate { get; private set; }

        public static Result<Pet> Create(PetId petId, string byName,
                                        string description, DateTime dateOfBirth,
                                        string color, string petHealthInfo,
                                        float weight, float height,
                                        bool isNeutered, bool isVaccinated,
                                        HelpStatus helpStatus, Address petAddress,
                                        string ownerPhoneNumber)
        {
            bool ValidationFailed = false;
            StringBuilder stringBuilder = new StringBuilder();
            string FailureDescription = string.Empty;
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
                return Result.Failure<Pet>($"Необходимо исправить следующие замечания:\r\n {FailureDescription}");
            }

            var pet = new Pet(petId, byName, description, dateOfBirth,
                              color, petHealthInfo, weight, height,
                              isNeutered, isVaccinated, helpStatus, petAddress,
                              ownerPhoneNumber);
            return Result.Success(pet);
        }

        public Result<IReadOnlyList<HelpRequisite>> AddRequisiteForHelp(HelpRequisite _requisiteForHelp)
        {
            return RequisitesForHelp.AddHelpRequisite(_requisiteForHelp);
        }
        public Result<IReadOnlyList<PetPhoto>> AddPetPhoto(PetPhoto petPhoto)
        {
            return Photos.AddPetPhoto(petPhoto);
        }

    }   
}
