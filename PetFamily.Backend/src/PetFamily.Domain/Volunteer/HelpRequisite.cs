using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
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

        public static implicit operator string(HelpRequisite helpRequisite) => helpRequisite.Name;
    }

    public record Requisites
    {
        protected Requisites() { }

        private readonly List<HelpRequisite> _RequisitesForHelp = [];
        public IReadOnlyList<HelpRequisite> RequisitesForHelp => _RequisitesForHelp;

        public Result<IReadOnlyList<HelpRequisite>, Error> AddHelpRequisite(HelpRequisite helpRequisite)
        {
            if (_RequisitesForHelp.Contains(helpRequisite))
                return Errors.General.ValueAlreadyExist(helpRequisite, nameof(RequisitesForHelp));

            _RequisitesForHelp.Add(helpRequisite);
            return _RequisitesForHelp;
        }

        public static Requisites Create() => new();

    }
}
