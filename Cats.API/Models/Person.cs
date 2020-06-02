using System.Collections.Generic;

namespace Cats.API
{
    public class Person
    {
        /// <summary>
        /// Name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gender of the person.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// Age of the person.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Pets of the person.
        /// </summary>
        public IEnumerable<Pet> Pets { get; set; }
    }
}
