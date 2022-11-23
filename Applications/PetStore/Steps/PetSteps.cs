using System.Collections.Generic;
using FluentAssertions;
using Gauge.CSharp.Lib.Attribute;
using Applications.PetStore.Swagger.Api;
using Applications.PetStore.Swagger.Model;
using Applications.PetStore.Swagger.Client;
using NUnit.Framework;

namespace Applications.PetStore.Steps
{
public class PetSteps
{
    private Dictionary<string, int> pet;
    private readonly PetApi _PetApi = new PetApi(StepsHelper.BasePath);

    [Step("Add Pet to Scenerio with <name> with <category>")]
    public void AddPet(string name, string cat)
    {
        var pet = new Pet(name: name, photoUrls: new List<string>());
        _PetApi.AddPet(pet);
        pet.Name.Should().Be(name);
    }

    [Step("Check that pet has <lol> with <cat>")]
    public void GetPet(string name, string cat)
    {
        _PetApi.GetPetById(11);
    }

    [Step("Delete a Pet <lol> with <cat>")]
    public void DeletePet(string name, string cat)
    {
        _PetApi.DeletePet(11, cat);
    }

    [Step("Verify that Pet is Deleted")]
        public void VerifyDeletedPet()
        {
            Assert.Throws<ApiException>(() => _PetApi.GetPetById(11));
        }
}
}