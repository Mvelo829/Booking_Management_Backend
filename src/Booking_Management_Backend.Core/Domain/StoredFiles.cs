using Abp.Domain.Entities.Auditing;
using Booking_Management_Backend.Domain.Attrinutes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Domain
{
    [Entity(TypeShortAlias = "frwk_StoredFiles")]
    public class StoredFile : FullAuditedEntity<Guid>
    {
        public virtual Person Owner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string OwnerType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual long? Size { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string FileName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string FileUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [NotMapped]
        public virtual IFormFile File { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Description { get; set; }
    }
}
