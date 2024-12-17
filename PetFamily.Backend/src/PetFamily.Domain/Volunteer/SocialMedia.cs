namespace PetFamily.Domain.Volunteer
{
    public class SocialMedia
    {
        public SocialMedia(string name, string link)
        {
            Name = name;
            Link = link;
        }
        public string Name { get; }
        public string Link { get; }
    }
}
