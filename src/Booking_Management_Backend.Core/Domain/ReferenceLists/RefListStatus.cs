using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Domain.ReferenceLists
{
    public enum RefListStatus:int
    {
        [Description("Not Started")]
        Inque =1,
        [Description("Started")]
        Started= 2,
        [Description("Inprogress")]
        Inprogress = 3,
        [Description("Completed")]
        Completed = 4,
    }
}
