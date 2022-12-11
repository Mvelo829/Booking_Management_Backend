using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Booking_Management_Backend.Configuration.Dto;

namespace Booking_Management_Backend.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : Booking_Management_BackendAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
