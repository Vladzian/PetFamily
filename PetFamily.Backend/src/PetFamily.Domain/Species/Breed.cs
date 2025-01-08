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
        public SpeciesId SpeciesId { get; }
        public Species Species { get;  }

        public static Result<Breed, Error> Create(BreedId breedId, string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
                return Errors.General.ValueIsRequired(nameof(Name));

            Breed breed = new Breed(breedId, name);
            return breed;
        }

        public static implicit operator string(Breed breed)  => breed.Name;
        
    }
}
