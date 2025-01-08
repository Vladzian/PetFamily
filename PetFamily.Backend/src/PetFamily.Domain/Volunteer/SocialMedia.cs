using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer
{
    public record SocialMedia
    {
        public const int MAX_NAME_LENGHT = 150;
        
        public SocialMedia(string name, string link)
        {
            Name = name;
            Link = link;
        }
        public string Name { get; }
        public string Link { get; }

        public static implicit operator string(SocialMedia socilaMedia) => socilaMedia.Name;
    }

    public record SocialMedias
    {
        private readonly List<SocialMedia> _SocialMedias = [];
        public IReadOnlyList<SocialMedia> ListSocialMedia => _SocialMedias;

        public Result<IReadOnlyList<SocialMedia>, Error> AddSocialMedia(SocialMedia socialMedia)
        {
            if (_SocialMedias.Contains(socialMedia))
                return Errors.General.ValueAlreadyExist(socialMedia, nameof(ListSocialMedia));

            _SocialMedias.Add(socialMedia);
            return _SocialMedias;
        }

        public static SocialMedias Create() => new();
        
    }
}
