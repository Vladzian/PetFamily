namespace PetFamily.Application.Volunteers.CreateVolunteer
{
    public record CreateVolunteerRequest(string fullName, string email, string generalDescription,
                                         string phoneNumber, byte experience = 0);
}
