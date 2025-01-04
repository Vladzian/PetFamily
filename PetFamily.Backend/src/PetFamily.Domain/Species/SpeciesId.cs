using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Species
{
    public record SpeciesId
    {
        private SpeciesId(Guid guid)
        {
            Value = guid;
        }
        public Guid Value { get; }
        public static SpeciesId NewEntityId() => new(Guid.NewGuid());
        public static SpeciesId Empty() => new(Guid.Empty);
        public static SpeciesId Create(Guid id) => new(id);
    }
}
