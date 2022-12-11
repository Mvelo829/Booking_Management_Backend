using System.Collections.Generic;

namespace Booking_Management_Backend.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
