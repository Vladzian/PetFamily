using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Shared
{
    public abstract class Entity<Tid> where Tid : notnull 
    {
        protected Entity(Tid id)
        {
            Id = id;
        }
        public Tid Id { get; private set; }
    }

    
}
