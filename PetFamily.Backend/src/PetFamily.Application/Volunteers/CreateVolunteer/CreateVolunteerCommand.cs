namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public record CreateVolunteerCommand(string fullName, string email, string generalDescription,
                                         string phoneNumber,  List<DtoSocialMedia> socialMedias, List<DtoHelpRequisite> helpRequisites, byte experience = 0);

    public record DtoSocialMedia(string name, string link);
    public record DtoHelpRequisite(string name, string desc);
}
