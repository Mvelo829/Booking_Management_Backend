using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using AutoMapper;
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
    public class BookingDetailsDto:EntityDto<Guid>
    {
        public Guid? PersonId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RegNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RefNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BookingDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EstimationHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RefListStatus? Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RefListCarWashOptions? CarWashOptions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CarWashOptionsName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? TotalAmount { get; set; }
    }
}
