using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Species
{
    public class BreedId : EntityId<BreedId>
    {
        public BreedId() { }
        public BreedId(Guid guid):base(guid) 
        {
        }
    }
}
