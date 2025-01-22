namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public record CreateVolunteerCommand(string FullName, string Email, string GeneralDescription,
                                         string PhoneNumber,  List<DtoSocialMedia> SocialMedias, List<DtoHelpRequisite> HelpRequisites, byte Experience = 0);

    public record DtoSocialMedia(string Name, string Link);
    public record DtoHelpRequisite(string Name, string Desc);
}
