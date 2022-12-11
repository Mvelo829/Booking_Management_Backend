using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Booking_Management_Backend.Controllers
{
    public abstract class Booking_Management_BackendControllerBase: AbpController
    {
        protected Booking_Management_BackendControllerBase()
        {
            LocalizationSourceName = Booking_Management_BackendConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
