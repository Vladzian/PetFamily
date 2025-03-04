using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Volunteer
{

    public record PetByName
    {
        private PetByName(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<PetByName, Error> Create(string byName)
        {
            if (string.IsNullOrWhiteSpace(byName))
            {
                Errors.General.ValueIsInvalid("ByName");
            }

            return new PetByName(byName);
        }
    }
}
