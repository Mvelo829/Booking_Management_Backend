using Abp.Application.Services;
using Booking_Management_Backend.Services.Dtos;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Services.BookingService
{
    public interface IBookingAppService:IApplicationService
    {
        Task<BookingDto> CreateAsync(BookingDto input);
        Task<BookingDto> GetAsync(Guid id);
        Task<List<BookingViewDto>> GetAllAsync();
        Task<BookingDetailsDto>GetBookingDetails(Guid id);
        Task<BookingDto> UpdateAsync(BookingDto input);
        Task<BookingDetailsDto> CancellBookingAsync(CancellBookingDto input);
        Task DeleteAsync(Guid Id);
    }
}
