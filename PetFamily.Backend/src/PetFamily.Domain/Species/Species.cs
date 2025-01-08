using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Species
{
    public class Species : Shared.Entity<SpeciesId>
    {
        //for ef core
        private Species(SpeciesId id) : base(id)
        {

        }
        private Species(SpeciesId speciesId, string name) : base(speciesId)
        {
            Name = name;
        }
        public string Name { get; set; }
        private readonly List<Breed> _Breeds = [];
        public IReadOnlyList<Breed> Breeds => _Breeds;
        public static Result<Species, Error> Create(SpeciesId speciesId, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Errors.General.ValueIsRequired(nameof(Name));

            Species species = new Species(speciesId, name);
            return species;
        }

        public Result<IReadOnlyList<Breed>, Error> AddBreed(Breed breed)
        {
            if (_Breeds.Contains(breed))
                return Errors.General.ValueAlreadyExist(breed, nameof(Breeds));

            _Breeds.Add(breed);
            return _Breeds;
        }
    }
}
