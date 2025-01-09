using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Volunteer
{
    public record PetPhoto
    {
        public const int MAX_PATH_LENGHT = 255;

        protected PetPhoto() { }

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

        public static implicit operator string(PetPhoto petPhoto) => petPhoto.Path;
    }

    public record PetPhotos
    {
        private readonly List<PetPhoto> _PetPhotos = [];
        public IReadOnlyList<PetPhoto> ListPhotos => _PetPhotos;

        public Result<IReadOnlyList<PetPhoto>, Error> AddPetPhoto(PetPhoto petPhoto)
        {
            if (_PetPhotos.Contains(petPhoto))
                return Errors.General.ValueAlreadyExist(petPhoto, nameof(ListPhotos));

            _PetPhotos.Add(petPhoto);
            return _PetPhotos;
        }
    }

}
