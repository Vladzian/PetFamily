using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static Result<Species> Create(SpeciesId speciesId, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Species>("Не задано наименование вида.");

            Species species = new Species(speciesId, name);
            return Result.Success<Species>(species);
        }

        public Result<IReadOnlyList<Breed>> AddBreed(Breed breed)
        {
            if (_Breeds.Contains(breed))
                return Result.Failure<IReadOnlyList<Breed>>($"В виде животного [{Name}] порода [{breed.Name}] уже присуствует.");

            _Breeds.Add(breed);
            return Result.Success<IReadOnlyList<Breed>>(Breeds);
        }
    }
}
