using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Volunteer
{
    public class RequisiteForHelp
    {
        //for ef core
        private RequisiteForHelp()
        {
            
        }
        public RequisiteForHelp(string name, string desc)
        {
            Name = name;
            Description = desc;
        }

        public string Name { get; }
        public string Description { get; }
    }
}
