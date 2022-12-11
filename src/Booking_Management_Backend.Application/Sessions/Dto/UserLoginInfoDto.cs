using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Booking_Management_Backend.Authorization.Users;

namespace Booking_Management_Backend.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
