using System.Collections.Generic;

namespace Cats.API.BAL
{
    public interface ICatLogic
    {
        /// <summary>
        /// Interface to get cats by the owner's gender.
        /// </summary>
        /// <param name="people">List of people</param>
        /// <returns>List of cats by owner's gender</returns>
        IEnumerable<CatsByOwnerGender> GetCatsByOwnerGender(IEnumerable<Person> people);
    }
}
