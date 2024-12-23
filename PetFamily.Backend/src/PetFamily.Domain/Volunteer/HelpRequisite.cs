using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Volunteer
{
    public record HelpRequisite
    {
        protected HelpRequisite(){}
        public HelpRequisite(string name, string desc)
        {
            Name = name;
            Description = desc;
        }
        public string Name { get; }
        public string Description { get; }
    }

    public record Requisites
    {
        protected Requisites() { }
        public IReadOnlyList<HelpRequisite> RequisitesForHelp { get; }

    }
}
