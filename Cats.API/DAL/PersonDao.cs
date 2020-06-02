using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cats.API.DAL
{
    public class PersonDao : IPersonDao
    {
        IConfiguration configuration = null;
        public PersonDao(IConfiguration configuration) => this.configuration = configuration;

        /// <summary>
        /// Gets the list of people.
        /// </summary>
        /// <returns>List of people</returns>
        public async Task<IEnumerable<Person>> GetPeople()
        {
            IEnumerable<Person> people = null;
            var apiEndpoint = configuration.GetSection("Endpoints").GetSection("Uri").Value;
            var action = configuration.GetSection("Endpoints").GetSection("Action").Value;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new System.Uri(apiEndpoint);
                var response = await client.GetAsync(action);

                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var peopleTask = response.Content.ReadAsAsync<IEnumerable<Person>>();
                    people = peopleTask.Result;
                }
            }

            return people;
        }
    }
}
