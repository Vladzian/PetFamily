using CSharpFunctionalExtensions;
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

        private readonly List<HelpRequisite> _RequisitesForHelp = [];
        public IReadOnlyList<HelpRequisite> RequisitesForHelp => _RequisitesForHelp;

        public Result<IReadOnlyList<HelpRequisite>> AddHelpRequisite(HelpRequisite helpRequisite)
        {
            if (_RequisitesForHelp.Contains(helpRequisite))
                return Result.Failure<IReadOnlyList<HelpRequisite>>("Данный реквизит уже существует в списке.");

            _RequisitesForHelp.Add(helpRequisite);
            return Result.Success(RequisitesForHelp);
        }

        public static Requisites Create() => new();

    }
}
