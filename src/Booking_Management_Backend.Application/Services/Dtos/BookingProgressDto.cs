using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities;
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
    public  class BookingProgressDto:EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EventName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  DateTime? LastModificationTime { get; set; }
    }

    public class updateProgresStatus : EntityDto<Guid>
    {
        public  RefListProgressStatus ProgressStatus { get; set; }
    }
}
