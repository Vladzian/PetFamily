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
            RuleFor(c => c.Info)
                .MustBeValueObject(vi => VolunteerInfo.Create(vi.Email, 
                                                              vi.GeneralDescription, 
                                                              vi.PhoneNumber, 
                                                              vi.Experience));
            RuleForEach(c => c.SocialMedias).MustBeValueObject(sm => SocialMedia.Create(sm.Name, sm.Link));
            RuleForEach(c => c.HelpRequisites).MustBeValueObject(hr => HelpRequisite.Create(hr.Name, hr.Desc));

            

        }
    }
}
