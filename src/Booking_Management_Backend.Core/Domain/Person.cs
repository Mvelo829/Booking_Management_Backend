using Abp.Domain.Entities.Auditing;
using Booking_Management_Backend.Authorization.Users;
using Booking_Management_Backend.Domain.Attrinutes;
using Booking_Management_Backend.Domain.ReferenceLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Domain
{
    [Entity(TypeShortAlias = "frwk_Person")]
    public class Person : FullAuditedEntity<Guid>
    {
        public virtual string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Surname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual int Age { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string EmailAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string CellPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListsGender? Gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string IdNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string HomeTelephoneNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string WorkTelephoneNumber { get; set; }
    }
}
