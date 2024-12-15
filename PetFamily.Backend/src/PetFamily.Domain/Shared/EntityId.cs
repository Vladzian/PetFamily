using CSharpFunctionalExtensions;
using PetFamily.Domain.Volunteer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Shared
{
    public class EntityId<T> : ComparableValueObject  where T : new()
    {
        private readonly T t;

        public EntityId()
        {
            
        }
        public EntityId(Guid guid)
        {
            Value = guid;
            t = new T();
        }
        public Guid Value { get; }
        public static EntityId<T> NewEntityId() => new(Guid.NewGuid());
        public static EntityId<T> Empty() => new(Guid.Empty);
        public static T Create (Guid id)  => new();
        
        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return Value;
        }
    }
}
