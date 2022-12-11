using System.Threading.Tasks;
using Booking_Management_Backend.Configuration.Dto;

namespace Booking_Management_Backend.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
