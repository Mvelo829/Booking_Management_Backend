using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Domain.ReferenceLists
{
    public  enum ReflistBookingStatus:int
    {
        [Description("Active")]
        Active = 1,
        [Description("Cancelled")]
        Cancelled = 2,
    }
}
