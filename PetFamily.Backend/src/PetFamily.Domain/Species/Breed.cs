using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Species
{
    public class Breed : Shared.Entity<BreedId>
    {
        //for ef core
        private Breed(BreedId id) : base(id)
        {
        }
        public Breed(BreedId breedId, string name) : base(breedId)
        {           
            Name = name;
        }

        public string Name {  get; private set; }
        public SpeciesId SpeciesId { get; private set; }
        public Species Species { get; private set; }

        public static Result<Breed> Create(BreedId breedId, string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<Breed>("Не задано название породы.");

            Breed breed = new Breed(breedId, name);
            return Result.Success<Breed>(breed);
        }
    }
}
