using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Domain.ReferenceLists
{
    public enum RefListCarWashOptions:int
    {
        [Description("1.Wash & Go")]
        WashAndGo = 1,
        [Description("2.Wash & Dry")]
        WashAndDry = 2,
        [Description("3.Premium Wash")]
        PremiumWash = 3,
        [Description("4.Super Wash")]
        SuperWash = 4,
        [Description("5.Full Valet")]
        FullValet = 5,
        [Description("6.Engine Steam Clean")]
        EnginSteamClean = 6,
        [Description("7.Chassis Steam Clean")]
        ChassisSteamClean = 7,
        [Description("8.Motor Bikes 125cc")]
        MotorBikes125cc = 8,
        [Description("9.Quads")]
        Quads = 9,
        [Description("10.Engine & Chassis Steam Clean")]
        EngineAndChassisSteamClean = 10,
        [Description("11.Mini Valet")]
        MiniValet = 11,
        [Description("12.Interior Valet")]
        InteriorValet = 12,
        [Description("13.Polish")]
        Polish = 13,
        [Description("14.Steam Cleaning")]
        SteamCleaning = 14,
        [Description("15.Detailed Valet")]
        DetailedValet = 15,
    }
}
