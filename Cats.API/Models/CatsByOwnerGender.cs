using System.Collections.Generic;

namespace Cats.API
{
    public class CatsByOwnerGender
    {
        /// <summary>
        /// Gender of owner.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// List of cats.
        /// </summary>
        public IEnumerable<string> Cats { get; set; }
    }
}
