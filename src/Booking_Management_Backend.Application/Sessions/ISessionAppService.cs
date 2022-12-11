using System.Threading.Tasks;
using Abp.Application.Services;
using Booking_Management_Backend.Sessions.Dto;

namespace Booking_Management_Backend.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
