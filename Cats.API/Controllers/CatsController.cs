using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cats.API.BAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Cats.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatsController : ControllerBase
    {
        private readonly IPersonLogic personLogic;
        private readonly ICatLogic catLogic;

        /// <summary>
        /// Constructor method.
        /// </summary>
        /// <param name="personLogic">Person logic layer.</param>
        /// <param name="catLogic">Cats logic layer.</param>
        public CatsController(IPersonLogic personLogic, ICatLogic catLogic)
        {
            this.personLogic = personLogic;
            this.catLogic = catLogic;
        }

        /// <summary>
        /// Gets the list of cats grouped by owner's gender.
        /// </summary>
        /// <returns>List of cats</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<CatsByOwnerGender>>> GetCats()
        {
            var people = await personLogic.GetPeople();
            if (people == null || people.Count() == 0)
            {
                return NotFound();
            }
            var catsByOwnerGender = catLogic.GetCatsByOwnerGender(people);

            return Ok(catsByOwnerGender);
        }
    }
}
