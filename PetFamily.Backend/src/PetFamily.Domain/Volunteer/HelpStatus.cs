using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PetFamily.Domain.Volunteer
{
    public enum HelpStatus //пока перечисление, но статусы могут меняться, стоит их завести как отдельную сущность в БД
    {
        NeedsHelp = 0,
        LookingForAHome = 1,
        FoundAHome = 2
    }

    //public class HelpStatus : Shared.Entity<HelpStatusId>
    //{
    //    //for ef core
    //    private HelpStatus(HelpStatusId id) : base(id)
    //    {
    //    }
    //    private HelpStatus(HelpStatusId id, string name, string description) : base(id)
    //    {
    //        Name = name;
    //        Description = description;
    //    }
    //    public string Name { get; private set; }
    //    public string Description { get; private set; }

    //    public static Result<HelpStatus> Create(HelpStatusId id, string name, string description)
    //    {
    //        bool ValidationFailed = false;
    //        StringBuilder stringBuilder = new StringBuilder();
    //        string FailureDescription = string.Empty;
    //        if (string.IsNullOrWhiteSpace(name))
    //        {
    //            ValidationFailed = true;
    //            stringBuilder.AppendLine("Не указано название нового статуса.");
    //        }
    //        if (ValidationFailed)
    //        {
    //            FailureDescription = stringBuilder.ToString();
    //            return Result.Failure<HelpStatus>($"Необходимо исправить следующие замечания:\r\n {FailureDescription}");
    //        }

    //        var helpStatus = new HelpStatus(id, name, description);
    //        return Result.Success(helpStatus);
    //    }

    //}

}
