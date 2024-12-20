using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Volunteer
{
    public record PetPhoto
    {
        private PetPhoto()
        {
            
        }
        private PetPhoto(string path, bool isMainFoto)
        {
            Path = path;
            IsMain = isMainFoto;
        }
        public string Path {get; }
        public bool IsMain { get; }

        public static Result<PetPhoto> Create(string path, bool isMainPhoto)
        {
            if (string.IsNullOrWhiteSpace(path))
                return Result.Failure<PetPhoto>("Необходимо указать путь к файлу фотографии");

            PetPhoto petPhoto = new PetPhoto(path, false);
            return Result.Success(petPhoto);
        }
    }
}
