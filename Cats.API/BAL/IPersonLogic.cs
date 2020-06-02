using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cats.API.BAL
{
    public interface IPersonLogic
    {
        /// <summary>
        /// Interface to get list of people.
        /// </summary>
        /// <returns>List of people</returns>
        Task<IEnumerable<Person>> GetPeople();
    }
}
