using CSharpFunctionalExtensions;
using PetFamily.Domain.Volunteer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Shared
{
    public record EntityId : IComparable<EntityId>
    {
        public EntityId(Guid guid)
        {
            Value = guid;
        }
        public Guid Value { get; }
        public static EntityId NewEntityId() => new(Guid.NewGuid());
        public static EntityId Empty() => new(Guid.Empty);

        public int CompareTo(EntityId? obj)
        {
            if (obj is null) 
                return 1;

            EntityId otherEntityId = obj;
            if (otherEntityId != null)
                return this.Value.CompareTo(obj.Value);
            else
                throw new ArgumentException("Object is not a EntityId");
        }
    }
}
