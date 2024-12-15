using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Volunteer
{
    public class SpeciesAndBreed : ComparableValueObject
    {
        public SpeciesAndBreed(SpeciesId speciesId, BreedId breedId)
        {
            SpeciesId = speciesId;
            BreedId = breedId;
        }
        public SpeciesId SpeciesId { get; }
        public BreedId BreedId { get; }

        protected override IEnumerable<IComparable> GetComparableEqualityComponents()
        {
            yield return SpeciesId;
            yield return BreedId;
        }
    }
}
