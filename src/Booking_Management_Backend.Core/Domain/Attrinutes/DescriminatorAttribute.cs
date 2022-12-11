using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Domain.Attrinutes
{ 
    public class DiscriminatorAttribute : Attribute
    {
        /// <summary>
        /// name of the discriminator column
        /// </summary>
        public string DiscriminatorColumn { get; set; }
        /// <summary>
        /// If true, indicates that entity uses discriminator
        /// </summary>

        public bool UseDiscriminator { get; set; }
        /// <summary>
        /// if true, indicates that the ORM should filter out rows with unknown discriminator values
        /// </summary>

        public bool FilterUnknokwnDiscriminators { get; set; }

        public DiscriminatorAttribute()
        {
            DiscriminatorColumn = "Person_Discriminator";
            UseDiscriminator = true;
            FilterUnknokwnDiscriminators = false;
        }
    }
}
