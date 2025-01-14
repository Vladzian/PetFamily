using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer
{
    public record SocialMedia
    {
        public const int MAX_NAME_LENGHT = 150;

        public SocialMedia()
        {            
        }
        public SocialMedia(string name, string link)
        {
            Name = name;
            Link = link;
        }
        public string Name { get; }
        public string Link { get; }

        public static Result<SocialMedia, Error> Create(string name, string link)
        {
            if (string.IsNullOrWhiteSpace(name))
                Errors.General.ValueIsInvalid(nameof(Name));

            if (string.IsNullOrWhiteSpace(link))           
                Errors.General.ValueIsInvalid(nameof(Link));            

            return new SocialMedia(name, link);
        }

        public static implicit operator string(SocialMedia socilaMedia) => socilaMedia.Name;
    }

    public record SocialMediaList
    {
        public SocialMediaList()
        {            
        }
        public SocialMediaList(IEnumerable<SocialMedia> socialMedias)
        {
            SocialMedias = socialMedias.ToList();
        }
        public IReadOnlyList<SocialMedia> SocialMedias { get; } = new List<SocialMedia>();

        public static SocialMediaList Create() => new SocialMediaList(new List<SocialMedia>());
    }
}
