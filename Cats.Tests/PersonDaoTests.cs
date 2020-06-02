using Cats.API;
using Cats.API.DAL;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cats.Tests
{
    [TestFixture]
    public class PersonDaoTests
    {
        public class WhenGettingPeople
        {
            IEnumerable<Person> peopleList = new List<Person>
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

            [Test]
            public void AListOfPeopleShouldBeReturned()
            {
                // arrange
                var apiEndpoint = "http://agl-developer-test.azurewebsites.net";
                var configuration = new Mock<IConfiguration>();
                configuration.Setup(c => c.GetSection("ApiEndpoint").GetSection("Uri").Value).Returns(apiEndpoint);

                // act
                var personDao = new Mock<IPersonDao>();
                personDao.Setup(p => p.GetPeople()).Returns(Task.FromResult(peopleList));

                var people = personDao.Object.GetPeople(); 

                // assert
                Assert.AreEqual(people.Result, peopleList);
            }
        }


    }
}
