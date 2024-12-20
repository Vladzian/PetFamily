using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PetFamily.Domain;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Species;
using PetFamily.Domain.Volunteer;
using PetFamily.Infrastructure;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ApplicationDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("get", () =>{

    //Address GoofyAddress = Address.NewAddress("Goofy", "Goofy", "Goofy", "Goofy", "Goofy", "Goofy");
    //Address MikkeyAddress = Address.NewAddress("Mikkey", "Mikkey", "Mikkey", "Mikkey", "Mikkey", "Mikkey");
    //Address TomAddress = Address.NewAddress("Tom", "Tom", "Tom", "Tom", "Tom", "Tom");

    //SpeciesAndBreed SpNBrGoofy = new SpeciesAndBreed(new SpeciesId(Guid.NewGuid()), new BreedId(Guid.NewGuid()));
    //SpeciesAndBreed SpNBrMikkey = new SpeciesAndBreed(new SpeciesId(Guid.NewGuid()), new BreedId(Guid.NewGuid()));
    //SpeciesAndBreed SpNBrTom = new SpeciesAndBreed(new SpeciesId(Guid.NewGuid()), new BreedId(Guid.NewGuid()));
    //var resultGoofy = Pet.Create(new PetId(Guid.NewGuid()), "Goofy", "Disney dog", SpNBrGoofy,
    //                    new DateTime(1932, 5, 27, 0, 0, 0, DateTimeKind.Utc), "black", "helthy", 70f, 175f, true, true,
    //                    HelpStatus.LookingForAHome, GoofyAddress, "+78888888888");
    
    //var resultMikkey = Pet.Create(new PetId(Guid.NewGuid()), "Mikkey", "Disney mouse", SpNBrMikkey,
    //                    new DateTime(1932, 5, 27, 0, 0, 0, DateTimeKind.Utc), "black", "helthy", 55f, 155f, true, true,
    //                    HelpStatus.LookingForAHome, MikkeyAddress, "+78888888888");
    //var resultTom = Pet.Create(new PetId(Guid.NewGuid()), "Tom", "Metro-Goldwyn-Mayer cat", SpNBrTom,
    //                    new DateTime(1932, 5, 27, 0, 0, 0, DateTimeKind.Utc), "grey", "helthy", 70f, 175f, true, true,
    //                    HelpStatus.FoundAHome, TomAddress, "+78888888888");

    //bool weHaveProblem = false;
    //StringBuilder errorStringBuilder = new StringBuilder();
    //if (resultGoofy.IsFailure)
    //{
    //    weHaveProblem = true;
    //    errorStringBuilder.AppendLine(resultGoofy.Error);
    //}
    //if (resultMikkey.IsFailure)
    //{
    //    weHaveProblem = true;
    //    errorStringBuilder.AppendLine(resultMikkey.Error);
    //}
    //if (resultTom.IsFailure)
    //{
    //    weHaveProblem = true;
    //    errorStringBuilder.AppendLine($"{resultTom.Error}");
    //}

    //if(weHaveProblem)
    //    return errorStringBuilder.ToString();


    //VolunteerId id = new VolunteerId(Guid.NewGuid());
    //var resultVolunteer = Volunteer.Create(id, "Elon Reeve Musk", "ElonMusk@starlink.org", "", "+7 888 888 88 88");

    //if(resultVolunteer.IsFailure)
    //    return $"Ќе удалось добавить нового волонтера:\r\n{resultVolunteer.Error}";

    //Volunteer volunteer = resultVolunteer.Value;

    //volunteer.AddPet(resultGoofy.Value);    
    //volunteer.AddPet(resultMikkey.Value);
    //volunteer.AddPet(resultTom.Value);

    //return $"volunteer has {volunteer.CountPetsFoundAHome()} pets founded a home \r\n"+
    //       $"volunteer has {volunteer.CountPetsLookingForAHome()} pets looking for a home \r\n" +
    //       $"volunteer has {volunteer.CountPetsNeedsHelp()} pets needs help \r\n";
});
await app.RunAsync();