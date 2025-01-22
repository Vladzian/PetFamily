using FluentValidation;
using PetFamily.Application.Validation;
using PetFamily.Domain.Volunteer;

namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public class CreateVolunteerCommandValidator : AbstractValidator<CreateVolunteerCommand>
    {
        public CreateVolunteerCommandValidator()
        {
            RuleFor(c => c.FullName).MustBeValueObject(VolunteerFullName.Create);
            RuleFor(c => new { c.Email, c.GeneralDescription, c.PhoneNumber, c.Experience })
                .MustBeValueObject(vi => VolunteerInfo.Create(vi.Email, 
                                                              vi.GeneralDescription, 
                                                              vi.PhoneNumber, 
                                                              vi.Experience));

            

        }
    }
}
