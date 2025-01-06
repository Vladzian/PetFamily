using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PetFamily.Domain.Volunteer
{
    public record PetInfo
    {        
        public const int PHONE_MAX_LENGHT = 16;
        public const int DESC_MAX_LENGHT = 512;
        public const int MAX_COLOR_LENGHT = 150;
        private PetInfo(string description, DateTime dateOfBirth,
                        string color, string petHealthInfo,
                        float weight, float height,
                        bool isNeutered, bool isVaccinated,
                        HelpStatus helpStatus, string ownerPhoneNumber)
        {
            Description = description;
            DateOfBirth = dateOfBirth;
            Color = color;
            PetHealthInfo = petHealthInfo;
            Weight = weight;
            Height = height;
            IsNeutered = isNeutered;
            IsVaccinated = isVaccinated;
            HelpStatus = helpStatus;
            OwnerPhoneNumber = ownerPhoneNumber;
        }

        public string Description { get; }
        public DateTime DateOfBirth { get; } = default!;
        public string Color { get; }
        public string PetHealthInfo { get; }
        public float Weight { get; }
        public float Height { get; }
        public bool IsNeutered { get; }
        public bool IsVaccinated { get; }
        public HelpStatus HelpStatus { get; }
        public string OwnerPhoneNumber { get; }

        public static Result<PetInfo, Error> Create(string description, DateTime dateOfBirth,
                                                    string color, string petHealthInfo,
                                                    float weight, float height,
                                                    bool isNeutered, bool isVaccinated,
                                                    HelpStatus helpStatus,  string ownerPhoneNumber)
        {
            if (string.IsNullOrWhiteSpace(description))
                return Errors.General.ValueIsRequired(nameof(Description));

            if (string.IsNullOrWhiteSpace(color))
                return Errors.General.ValueIsRequired(nameof(Color));

            if (string.IsNullOrWhiteSpace(petHealthInfo)) 
                return Errors.General.ValueIsRequired(nameof(PetHealthInfo));

            if (string.IsNullOrWhiteSpace(ownerPhoneNumber))
                return Errors.General.ValueIsRequired(nameof(OwnerPhoneNumber));

            //честно найдено в интернете (https://habr.com/ru/articles/110731/) - не проверял
            Regex regex = new Regex(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$");
            if (!regex.IsMatch(ownerPhoneNumber))
                return Errors.General.ValueIsIncorrect(nameof(OwnerPhoneNumber));

            return new PetInfo(description, dateOfBirth, 
                               color, petHealthInfo, 
                               weight, height,
                               isNeutered, isVaccinated, 
                               helpStatus, ownerPhoneNumber);
        }
    }
}
