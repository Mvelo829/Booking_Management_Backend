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
    public class BookingDto:EntityDto<Guid>
    {
        public  Guid? PersonId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string IdNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Cellno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EmailAdress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string RegNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string RefNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string QueNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string VehicleMake { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  DateTime? BookingDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string EstimationHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  RefListStatus? Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string StatusName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  RefListCarWashOptions? CarWashOptions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string CarWashOptionsName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  double? Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  double? TotalAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  ReflistBookingStatus? BookingStatus { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public  string BookingStatusName { set; get; }

    }
}
