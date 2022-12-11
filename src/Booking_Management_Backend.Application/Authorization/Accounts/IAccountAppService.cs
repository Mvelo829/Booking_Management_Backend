using System.Threading.Tasks;
using Abp.Application.Services;
using Booking_Management_Backend.Authorization.Accounts.Dto;

namespace Booking_Management_Backend.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
