using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Domain.ReferenceLists
{
    public enum RefListProgressStatus:int
    {
        [Description("Online Booking")]
        OnlineBooking = 1,
        [Description("At Spot")]
        AtSpot = 2, 
        [Description("Washing")]
        Washing = 3,
        [Description("Done")]
        Done = 4,
        [Description("Thank You")]
        Fetched = 5,
    }
}
