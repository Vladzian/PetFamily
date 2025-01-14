using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer
{
    public record HelpRequisite
    {
        public const int MAX_NAME_LENGHT = 150;
        public const int MAX_DESC_LENGHT = 512;
        public HelpRequisite() { }
        public HelpRequisite(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
        public string Name { get; }
        public string Description { get; }
        public static Result<HelpRequisite, Error> Create(string name, string desc)
        {
            if (string.IsNullOrWhiteSpace(name))
                Errors.General.ValueIsInvalid(nameof(Name));

            if (string.IsNullOrWhiteSpace(desc))
                Errors.General.ValueIsInvalid(nameof(Description));

            return new HelpRequisite(name, desc);
        }
        public static implicit operator string(HelpRequisite helpRequisite) => helpRequisite.Name;
    }

    public record HelpRequisiteList
    {
        public HelpRequisiteList()
        {
        }
        public HelpRequisiteList(IEnumerable<HelpRequisite> helpRequisites)
        {
            HelpRequisites = helpRequisites.ToList();
        }
        public IReadOnlyList<HelpRequisite> HelpRequisites { get; }

        public static HelpRequisiteList Create() => new HelpRequisiteList(new List<HelpRequisite>() );
    }
}
