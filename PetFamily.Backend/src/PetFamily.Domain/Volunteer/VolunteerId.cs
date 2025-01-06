using PetFamily.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Volunteer
{
    public record VolunteerId
    {
        private VolunteerId(Guid guid)
        {
            Value = guid;
        }
        public Guid Value { get; }
        public static VolunteerId NewEntityId() => new(Guid.NewGuid());
        public static VolunteerId Empty() => new(Guid.Empty);
        public static VolunteerId Create(Guid id) => new(id);

        public static implicit operator VolunteerId(Guid id) => new VolunteerId(id);

        public static implicit operator Guid(VolunteerId volunteerId)
        {
            ArgumentNullException.ThrowIfNull(volunteerId);
            return volunteerId.Value;
        }
    }
}
