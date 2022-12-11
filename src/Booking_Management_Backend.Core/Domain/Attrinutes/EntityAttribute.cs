using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Domain.Attrinutes
{
    public class EntityAttribute : Attribute
    {
        /// <summary>
        /// Specifies friendly name of the entity that should be shown when required
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// short version of the Type name of the entity class that is unique within
        /// all the entities in the current solution
        /// characters must be 3o or less
        /// the discriminator value defined for the entity on Nhibernate mapping if the entity is a subclass of another class
        /// </summary>
        public string TypeShortAlias { get; set; }
    }
}
