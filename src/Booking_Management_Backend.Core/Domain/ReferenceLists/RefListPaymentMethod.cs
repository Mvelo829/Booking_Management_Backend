using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Domain.ReferenceLists
{
    public enum RefListPaymentMethod : int
    {
        [Description("1.Debit order")]
        DebitOrder = 1,
        [Description("2.Bank deposit")]
        BankDeposit = 2,
        [Description("3.Electronic funds transfer")]
        ElectronicFunds = 3
    }
}
