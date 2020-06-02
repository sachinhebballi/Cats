using Cats.API;
using Cats.API.BAL;
using Cats.API.Controllers;
using Cats.API.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cats.Tests
{
    [TestFixture]
    public class CatsControllerTests
    {
        private readonly IEnumerable<Person> peopleList = new List<Person>
            {
                new Person
                {
                    Name = "Bob",
                    Age = 23,
                    Gender = "Male",
                    Pets = new List<Pet>
                    {
                        new Pet
                        {
                            Name = "Garfield",
                            Type = PetType.Cat
                        }
                    }
                }
            };

        private readonly IEnumerable<CatsByOwnerGender> catsList = new List<CatsByOwnerGender>
            {
                new CatsByOwnerGender
                {
                    Gender = "Male",
                    Cats = new List<string>{"Garfield", "Fido" }
                },
                new CatsByOwnerGender
                {
                    Gender = "Female",
                    Cats = new List<string>{"Tabby", "Alice" }
                }
            };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ShouldReturnListOfCatsByOwnersGender()
        {
            // arrange
            var personLogic = new Mock<IPersonLogic>();
            var catLogic = new Mock<ICatLogic>();
            var personDao = new Mock<IPersonDao>();
            var configuration = new Mock<IConfiguration>();
            var catsController = new CatsController(personLogic.Object, catLogic.Object);

            personLogic.Setup(p => p.GetPeople()).Returns(Task.FromResult(peopleList));
            personDao.Setup(p => p.GetPeople()).Returns(Task.FromResult(peopleList));

            catLogic.Setup(p => p.GetCatsByOwnerGender(peopleList)).Returns(catsList);

            var cats = await catsController.GetCats();

            // assert
            Assert.AreEqual(catsList, ((OkObjectResult)cats.Result).Value);
        }

        [Test]
        public async Task ShouldReturnNotFoundWhenThereAreNoPeople()
        {
            // arrange
            var personLogic = new Mock<IPersonLogic>();
            var catLogic = new Mock<ICatLogic>();
            var personDao = new Mock<IPersonDao>();
            var configuration = new Mock<IConfiguration>();
            var catsController = new CatsController(personLogic.Object, catLogic.Object);
            IEnumerable<Person> emptyPerson = new List<Person>();
            IEnumerable<CatsByOwnerGender> emptyCats = new List<CatsByOwnerGender>();

            personLogic.Setup(p => p.GetPeople()).Returns(Task.FromResult(emptyPerson));
            personDao.Setup(p => p.GetPeople()).Returns(Task.FromResult(emptyPerson));

            catLogic.Setup(p => p.GetCatsByOwnerGender(peopleList)).Returns(emptyCats);

            var cats = await catsController.GetCats();

            // assert
            Assert.AreEqual(404, ((NotFoundResult)cats.Result).StatusCode);
        }
    }
}