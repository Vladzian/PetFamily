using CSharpFunctionalExtensions;

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
    }

    public record SocialMedias
    {
        private readonly List<SocialMedia> _SocialMedias = [];
        public IReadOnlyList<SocialMedia> ListSocialMedia => _SocialMedias;

        public Result<IReadOnlyList<SocialMedia>> AddSocialMedia(SocialMedia socialMedia)
        {
            if (_SocialMedias.Contains(socialMedia))
                return Result.Failure<IReadOnlyList<SocialMedia>>("Такая соцсеть уже добавлена");

            _SocialMedias.Add(socialMedia);
            return Result.Success(ListSocialMedia);
        }
    }
}
