using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Domain.ReferenceLists
{
    public enum RefListsGender : int
    {
        [Description("1.Male")]
        Male = 1,
        [Description("2.Female")]
        Female = 2,
        [Description("3.Other")]
        Other = 3
    }
}
