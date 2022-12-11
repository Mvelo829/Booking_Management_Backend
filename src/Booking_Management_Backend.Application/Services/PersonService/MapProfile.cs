using AutoMapper;
using Booking_Management_Backend.Authorization.Users;
using Booking_Management_Backend.Domain;
using Booking_Management_Backend.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Services.PersonService
{
    public class StoredFileMapingProfile : Profile
    {
        public StoredFileMapingProfile()
        {
            CreateMap<Person, PersonDto>();
              
            CreateMap<PersonDto, Person>()
               .ForMember(e => e.Id, m => m.Ignore());

            CreateMap<PersonDto, User>()
               .ForMember(e => e.Id, m => m.Ignore());
        }
    }
}
