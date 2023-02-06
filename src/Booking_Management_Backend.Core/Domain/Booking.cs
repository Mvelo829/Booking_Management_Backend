using Abp.Domain.Entities.Auditing;
using Booking_Management_Backend.Domain.ReferenceLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Domain
{
    public class Booking:FullAuditedEntity<Guid>
    {
        public virtual Person Person { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string RegNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string RefNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string QueNo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string VehicleMake { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? BookingDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string EstimationHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListStatus? Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListCarWashOptions? CarWashOptions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual double? Amount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual double? TotalAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual ReflistBookingStatus? BookingStatus { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListProgressStatus? ProgressStatus { set; get; }
    }
}
