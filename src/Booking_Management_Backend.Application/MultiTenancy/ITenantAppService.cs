using Abp.Application.Services;
using Booking_Management_Backend.MultiTenancy.Dto;

namespace Booking_Management_Backend.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

