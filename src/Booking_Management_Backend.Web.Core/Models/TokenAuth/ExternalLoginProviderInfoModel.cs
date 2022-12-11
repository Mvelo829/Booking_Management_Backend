using Abp.AutoMapper;
using Booking_Management_Backend.Authentication.External;

namespace Booking_Management_Backend.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
