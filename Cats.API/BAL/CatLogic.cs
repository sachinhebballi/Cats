using System.Collections.Generic;
using System.Linq;

namespace Cats.API.BAL
{
    /// <summary>
    /// Logic layer for Cats
    /// </summary>
    public class CatLogic : ICatLogic
    {
        /// <summary>
        /// Gets the list of cats by the owner's gender.
        /// </summary>
        /// <param name="people">List of people</param>
        /// <returns>List of cats by owner's gender</returns>
        public IEnumerable<CatsByOwnerGender> GetCatsByOwnerGender(IEnumerable<Person> people)
        {
            var catsByOwnerGender = (from p in people
                                     group p by p.Gender into g
                                     select new CatsByOwnerGender
                                     {
                                         Gender = g.Key,
                                         Cats = g.Where(p => p.Pets != null)
                                         .SelectMany(p => p.Pets)
                                         .Where(p => p.Type == PetType.Cat)
                                         .OrderBy(p => p.Name)
                                         .Select(p => p.Name)
                                     }).ToList();

            return catsByOwnerGender;
        }
    }
}
