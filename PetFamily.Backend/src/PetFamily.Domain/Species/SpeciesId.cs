using PetFamily.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Species
{
    public class SpeciesId : EntityId
    {
        public SpeciesId(Guid guid) : base(guid)
        {
            
        }
    }
}
