using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Booking_Management_Backend.MultiTenancy;

namespace Booking_Management_Backend.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
