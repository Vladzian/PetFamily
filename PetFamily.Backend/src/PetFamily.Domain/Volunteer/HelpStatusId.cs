namespace PetFamily.Domain.Volunteer
{
    public record HelpStatusId
    {
        private HelpStatusId(Guid guid)
        {
            Value = guid;
        }
        public Guid Value { get; }
        public static HelpStatusId NewEntityId() => new(Guid.NewGuid());
        public static HelpStatusId Empty() => new(Guid.Empty);
        public static HelpStatusId Create(Guid id) => new(id);
    }
}