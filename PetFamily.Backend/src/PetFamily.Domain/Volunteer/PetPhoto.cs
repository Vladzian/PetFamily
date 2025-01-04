using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PetFamily.Domain.Volunteer
{
    public record PetPhoto
    {
        public const int MAX_PATH_LENGHT = 255;

        protected PetPhoto(){}

        private PetPhoto(string path, bool isMainFoto)
        {
            Path = path;
            IsMain = isMainFoto;
        }

        public string Path { get; }
        public bool IsMain { get; }

        public static Result<PetPhoto> Create(string path, bool isMainPhoto)
        {
            if (string.IsNullOrWhiteSpace(path))
                return Result.Failure<PetPhoto>("Необходимо указать путь к файлу фотографии");

            PetPhoto petPhoto = new PetPhoto(path, false);
            return Result.Success(petPhoto);
        }
    }

    public record PetPhotos
    {
        private readonly List<PetPhoto> _PetPhotos = [];
        public IReadOnlyList<PetPhoto> ListPhotos => _PetPhotos;

        public Result<IReadOnlyList<PetPhoto>> AddPetPhoto(PetPhoto petPhoto)
        {
            if (_PetPhotos.Contains(petPhoto))
                return Result.Failure<IReadOnlyList<PetPhoto>>("Такое фото уже существует в коллекции питомца.");

            _PetPhotos.Add(petPhoto);
            return Result.Success(ListPhotos);
        }
    }
    
}
