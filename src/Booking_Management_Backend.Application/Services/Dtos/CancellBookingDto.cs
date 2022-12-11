using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Booking_Management_Backend.Domain;
using Booking_Management_Backend.Domain.ReferenceLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Services.Dtos
{
    [AutoMap(typeof(Booking))]
    public class CancellBookingDto:EntityDto<Guid>
    {
        public ReflistBookingStatus? BookingStatus { set; get; }
    }
}
