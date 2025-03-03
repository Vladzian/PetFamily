namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public record CreateVolunteerCommand(string FullName, DtoVolunteerInfo Info,  List<DtoSocialMedia> SocialMedias, List<DtoHelpRequisite> HelpRequisites);

    public record DtoVolunteerInfo(string Email, string GeneralDescription, string PhoneNumber, byte Experience = 0);
    public record DtoSocialMedia(string Name, string Link);
    public record DtoHelpRequisite(string Name, string Desc);
}
