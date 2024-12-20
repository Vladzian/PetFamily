using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace PetFamily.Domain.Volunteer
{
    public sealed class Volunteer : Shared.Entity<VolunteerId>
    {
        //for ef core
        private Volunteer(VolunteerId id) : base(id)
        {            
        }
        public Volunteer(VolunteerId volunteerId, string fullName,
                         string email, string generalDescription, 
                         string phoneNumber, byte experience) : base(volunteerId)
        {      
            FullName = fullName;
            Email = email;
            GeneralDescription = generalDescription;
            PhoneNumber = phoneNumber;
            Experience = experience;
        }
        public string FullName { get; private set; }
        public string Email { get; private set; }    
        public string GeneralDescription { get; private set; }
        public string PhoneNumber { get; private set; }
        public byte Experience { get; private set; }


        private readonly List<SocialMedia> _SocialMedias = [];
        public IReadOnlyList<SocialMedia> SocialMedias => _SocialMedias;

        private readonly List<RequisiteForHelp> _RequisitesForHelp = [];
        public IReadOnlyList<RequisiteForHelp> RequisitesForHelp => _RequisitesForHelp;

        private readonly List<Pet> _Pets = [];
        public IReadOnlyList<Pet> Pets => _Pets;

        public ushort CountPets(HelpStatus status)
        {
            return (ushort)_Pets.Count;
        }
        public ushort CountPetsByStatus(HelpStatus status) 
        {            
            return (ushort)_Pets.Count(p => p.HelpStatus == status); 
        }
        public ushort CountPetsFoundAHome() 
        {
            return CountPetsByStatus(HelpStatus.FoundAHome);
        }
        public ushort CountPetsLookingForAHome()
        {
            return CountPetsByStatus(HelpStatus.LookingForAHome);
        }
        public ushort CountPetsNeedsHelp()
        {
            return CountPetsByStatus(HelpStatus.NeedsHelp);
        }

        public Result<IReadOnlyList<Pet>> AddPet(Pet pet)
        {
            if (_Pets.Contains(pet))
                return Result.Failure<IReadOnlyList<Pet>>("Этот питомец уже добавлен в коллекцию волонтера");

            _Pets.Add(pet);
            return Result.Success(Pets);
        }

        public static Result<Volunteer> Create(VolunteerId volunteerId, string fullName, 
                                        string email, string generalDescription, 
                                        string phoneNumber, byte experience = 0)
        {
            bool ValidationFailed = false;
            StringBuilder stringBuilder = new StringBuilder();

            if (string.IsNullOrWhiteSpace(fullName))
            {
                ValidationFailed = true;
                stringBuilder.AppendLine("Не указаны ФИО.");
            }
            Regex emailRegex = new Regex(@"^.+@.+\..+");// полез искать регулярку и попал на эту статью https://habr.com/ru/articles/175375/
            if (string.IsNullOrWhiteSpace(email) || !emailRegex.IsMatch(email))
            {
                ValidationFailed = true;
                stringBuilder.AppendLine("Введите корреткный адрес электронной почты.");
            }
            Regex regex = new Regex(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$");
            if (!regex.IsMatch(phoneNumber))
            {
                ValidationFailed = true;
                stringBuilder.AppendLine("Некорректно указан номер волонтера.");
            }

            if (ValidationFailed)
            {
                return Result.Failure<Volunteer>($"Необходимо исправить следующие замечания:\r\n {stringBuilder.ToString()}");
            }

            var volunteer = new Volunteer(volunteerId, fullName, email, generalDescription, phoneNumber, experience);
            return Result.Success(volunteer);
        }
    }
}
