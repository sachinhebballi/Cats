using Cats.API.DAL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cats.API.BAL
{
    public class PersonLogic : IPersonLogic
    {
        /// <summary>
        /// Person data layer.
        /// </summary>
        private IPersonDao personDao = null;

        /// <summary>
        /// Constructor method.
        /// </summary>
        /// <param name="personDao">Person data layer</param>
        public PersonLogic(IPersonDao personDao) => this.personDao = personDao;

        /// <summary>
        /// Gets the list of people.
        /// </summary>
        /// <returns>List of people</returns>
        public async Task<IEnumerable<Person>> GetPeople()
        {
            return await personDao.GetPeople();
        }
    }
}
