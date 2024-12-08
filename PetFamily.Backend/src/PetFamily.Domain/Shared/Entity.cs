using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Shared
{
    public abstract class Entity<TId> where TId : notnull
    {
        protected Entity(TId _id) 
        {
            Id = _id;
        }
        public TId Id { get; private set; }
    }
}
