using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;

namespace PetFamily.Domain.Volunteer
{
    public record PetSpecie
    {
        private PetSpecie(Guid? specieId, Guid? breedId)
        {
            SpecieId = specieId;
            BreedId = breedId;
        }
        public Guid? SpecieId { get; }
        public Guid? BreedId { get; }

        public static Result<PetSpecie, Error> Create(SpeciesId? specieId, BreedId? breedId)
        {
            Guid? idSpecie = null;
            Guid? idBreed = null;

            if (specieId != null)
                idSpecie = specieId.Value;

            if (breedId != null)
                idBreed = breedId.Value;

            return new PetSpecie(idSpecie, idBreed);
        }
        public static PetSpecie Empty() => new(null, null);

    }
}
