using Booking_Management_Backend.Debugging;

namespace Booking_Management_Backend
{
    public class Booking_Management_BackendConsts
    {
        public const string LocalizationSourceName = "Booking_Management_Backend";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "db09537f2630424eaaa2c11900412623";
    }
}
