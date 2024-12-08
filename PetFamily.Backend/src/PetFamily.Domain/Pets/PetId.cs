using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Pets
{
    public record PetId
    {
        private PetId(Guid _guid)
        {
            Value = _guid;
        }
        public Guid Value { get; }
        public static PetId NewPetId() => new(Guid.NewGuid());
        public static PetId Empty() => new(Guid.Empty);
    }



}
