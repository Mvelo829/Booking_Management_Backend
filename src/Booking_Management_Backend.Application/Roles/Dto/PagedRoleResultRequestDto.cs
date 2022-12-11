using Abp.Application.Services.Dto;

namespace Booking_Management_Backend.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

