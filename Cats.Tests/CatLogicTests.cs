using Cats.API;
using Cats.API.BAL;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;

namespace Cats.Tests
{
    [TestFixture]
    public class CatLogicTests
    {
        public class WhenGettingCats
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

            [Test]
            public void ItShouldReturnListOfCatsByOwnersGender()
            {
                // arrange
                var catLogic = new Mock<ICatLogic>();
                catLogic.Setup(c => c.GetCatsByOwnerGender(peopleList)).Returns(catsList);

                // act

                var cats = catLogic.Object.GetCatsByOwnerGender(peopleList);

                // assert
                Assert.AreEqual(cats, catsList);
            }
        }


    }
}
