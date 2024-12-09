using PetFamily.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Volunteer
{
    public record VolunteerId : EntityId
    {
        private VolunteerId(Guid _guid) : base(_guid)
        {
            
        }        
    }
}
