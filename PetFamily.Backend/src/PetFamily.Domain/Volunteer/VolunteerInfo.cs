using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using System.Text.RegularExpressions;

namespace PetFamily.Domain.Volunteer
{
    public record VolunteerInfo
    {
        public const int EMAIL_MAX_LENGHT = 150;
        public const int PHONE_MAX_LENGHT = 16;
        public const int DESC_MAX_LENGHT = 512;
        private VolunteerInfo(string email, string generalDescription, string phoneNumber, byte experience = 0)
        {
            Email = email;
            GeneralDescription = generalDescription;
            PhoneNumber = phoneNumber;
            Experience = experience;
        }
        public string Email { get; }
        public string GeneralDescription { get; }
        public string PhoneNumber { get; }
        public byte Experience { get; }

        public static Result<VolunteerInfo, IEnumerable<Error>> Create(string email, string generalDescription, string phoneNumber, byte experience = 0)
        {
            List<Error> errors = [];
            if (string.IsNullOrWhiteSpace(email))
                errors.Add(Errors.General.ValueIsRequired(nameof(Email)));

            Regex emailRegex = new Regex(@"^.+@.+\..+");// полез искать регулярку и попал на эту статью https://habr.com/ru/articles/175375/
            if (!emailRegex.IsMatch(email))
                errors.Add(Errors.General.ValueIsIncorrect(nameof(Email)));

            if (string.IsNullOrWhiteSpace(phoneNumber))
                errors.Add(Errors.General.ValueIsRequired(nameof(PhoneNumber)));

            Regex regex = new Regex(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$");
            if (!regex.IsMatch(phoneNumber))
                errors.Add(Errors.General.ValueIsIncorrect(nameof(PhoneNumber)));

            if (errors.Count > 0)
                return errors;


            return new VolunteerInfo(email, generalDescription, phoneNumber, experience);
        }
    }
}
