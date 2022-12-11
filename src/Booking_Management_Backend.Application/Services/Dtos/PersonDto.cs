using Abp.Application.Services.Dto;
using AutoMapper;
using Booking_Management_Backend.Authorization.Users;
using Booking_Management_Backend.Domain;
using Booking_Management_Backend.Domain.ReferenceLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Services.Dtos
{
    [AutoMap(typeof(Person))]
    public class PersonDto:EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public  string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? UserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string Surname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  int Age { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string EmailAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string CellPhone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  RefListsGender? Gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string IdNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string HomeTelephoneNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public  string WorkTelephoneNumber { get; set; }
    }
}
