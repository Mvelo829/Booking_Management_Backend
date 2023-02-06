using AutoMapper;
using Booking_Management_Backend.Configuration;
using Booking_Management_Backend.Domain;
using Booking_Management_Backend.Domain.ReferenceLists;
using Booking_Management_Backend.Services.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Services.BookingService
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Booking, BookingDetailsDto>()
                .ForMember(e => e.PersonId, m => m.MapFrom(a => a.Person != null ? a.Person.Id : (Guid?)null))
                .ForMember(e => e.StatusName, m => m.MapFrom(a => a.Status != null ? a.Status.GetRefListText() : null))
                .ForMember(e => e.CarWashOptionsName, m => m.MapFrom(a => a.CarWashOptions != null ? a.CarWashOptions.GetRefListText() : null));

            CreateMap<Booking, BookingDto>()
                .ForMember(e => e.PersonId, m => m.MapFrom(a => a.Person != null ? a.Person.Id : (Guid?)null))
                .ForMember(e=>e.StatusName,m=>m.MapFrom(a=>a.Status!=null? a.Status.GetRefListText():null))
                .ForMember(e=>e.BookingStatusName,m=>m.MapFrom(a=>a.BookingStatus!=null? a.BookingStatus.GetRefListText():null))
                .ForMember(e=>e.CarWashOptionsName,m=>m.MapFrom(a=>a.CarWashOptions!=null? a.CarWashOptions.GetRefListText():null))
                .ForMember(e=>e.Name,m=>m.MapFrom(a=>a.Person!=null? a.Person.Name:null))
                .ForMember(e=>e.Surname,m=>m.MapFrom(a=>a.Person!=null? a.Person.Surname:null))
                .ForMember(e=>e.IdNumber,m=>m.MapFrom(a=>a.Person!=null? a.Person.IdNumber:null))
                .ForMember(e=>e.Cellno,m=>m.MapFrom(a=>a.Person!=null? a.Person.CellPhone:null));

            CreateMap<Booking, BookingProgressDto>()
               .ForMember(e => e.EventName, m => m.MapFrom(a => a.ProgressStatus != null ? a.ProgressStatus.GetRefListText() : null));

            CreateMap<BookingDto, Booking>()
               .ForMember(e => e.Id, m => m.Ignore());

            CreateMap<BookingDto, Person>()
               .ForMember(e => e.Id, m => m.Ignore());
        }
      
    }
}
