using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer
{
    public record VolunteerFullName
    {
        private VolunteerFullName(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<VolunteerFullName, Error> Create(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                Errors.General.ValueIsInvalid("FulllName");
            }

            return new VolunteerFullName(fullName);
        }
    }
}