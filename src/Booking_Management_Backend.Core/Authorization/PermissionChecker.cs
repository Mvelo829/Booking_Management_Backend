using Abp.Authorization;
using Booking_Management_Backend.Authorization.Roles;
using Booking_Management_Backend.Authorization.Users;

namespace Booking_Management_Backend.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
