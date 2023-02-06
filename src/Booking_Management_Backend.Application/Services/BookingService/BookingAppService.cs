using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Runtime.Validation;
using Booking_Management_Backend.Configuration;
using Booking_Management_Backend.Domain;
using Booking_Management_Backend.Services.Dtos;
using Booking_Management_Backend.Services.PersonService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Services.BookingService
{
    public class BookingAppService : ApplicationService, IBookingAppService
    {
        private readonly IRepository<Booking, Guid> _bookingRepository;
        private readonly IRepository<Person, Guid> _personRepository;
        private readonly IPersonAppService _personAppService;
        public BookingAppService(IRepository<Booking, Guid> bookingRepository, IRepository<Person, Guid> personRepository, IPersonAppService personAppService)
        {
            _bookingRepository = bookingRepository;
            _personRepository = personRepository;
            _personAppService = personAppService;
        }

        [HttpPost]
        public async Task<BookingDto> CreateBookingAndPersonAsync(BookingDto input)
        {
            var person = new Person();
            person = _personRepository.GetAll().ToList().Where(x => x.IdNumber == input?.IdNumber).FirstOrDefault();
            if(person == null)
            {
                var personInput = new PersonDto
                {
                    Name = input.Name,
                    Surname = input.Surname,
                    IdNumber = input.IdNumber,
                    CellPhone = input.Cellno,
                    EmailAddress = input.EmailAdress
                };
                await _personAppService.CreateAsync(personInput);
                await CurrentUnitOfWork.SaveChangesAsync();
                person = _personRepository.GetAll().ToList().Where(x => x.IdNumber == input.IdNumber).FirstOrDefault();
            }
            var booking = ObjectMapper.Map<Booking>(input);
            booking.Person = person;
            booking.RefNumber = $"Ref{GetUniqueName("RefNumber").GetHashCode().ToString()}";
            await _bookingRepository.InsertAsync(booking);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> CreateAsync(BookingDto input)
        {
            var person = new Person();
            person = _personRepository.GetAll().ToList().Where(x => x.IdNumber == input?.IdNumber).FirstOrDefault();
            if (person == null)
                throw new AbpValidationException("", new List<ValidationResult> { new ValidationResult($"Person NotFound") });
            var booking = ObjectMapper.Map<Booking>(input);
            booking.Person = person;
            booking.RefNumber = $"Ref{GetUniqueName("RefNumber").GetHashCode().ToString()}";
            await _bookingRepository.InsertAsync(booking);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<BookingDto>(booking);
        }


        [HttpPost]
        public async Task<BookingDetailsDto> CancellBookingAsync(CancellBookingDto input)
        {
            var booking = _bookingRepository.GetAllIncluding(x => x.Person).Where(x => x.Id == input.Id).FirstOrDefault();
            booking.BookingStatus = input.BookingStatus;
            await _bookingRepository.UpdateAsync(booking);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<BookingDetailsDto>(booking);
        }

        [HttpGet]
        public async Task<List<BookingViewDto>> GetAllAsync()
        {
            var bookings = await _bookingRepository.GetAllListAsync();
            return ObjectMapper.Map<List<BookingViewDto>>(bookings);
        }

        [HttpGet]
        public async Task<BookingDto> GetAsync(Guid id)
        {
            var booking = _bookingRepository.GetAllIncluding(x => x.Person).Where(x => x.Id == id).FirstOrDefault();
            return ObjectMapper.Map<BookingDto>(booking);
        }

        [HttpGet]
        public async Task<BookingProgressDto> GetProgresStatus(Guid id)
        {
            var booking = _bookingRepository.GetAllIncluding(x => x.Person).Where(x => x.Id == id).FirstOrDefault();
            var response = ObjectMapper.Map<BookingProgressDto>(booking);
            response.Description = await SwitchEventName(response.EventName);
            return ObjectMapper.Map<BookingProgressDto>(booking);
        }

        [HttpGet]
        public async Task<List<BookingViewDto>> GetBookingHistoryAsync(string IdNumber)
        {
            var twoMonthsAgo = DateTime.Now.AddMonths(-2);
            var historyRecord = _bookingRepository.GetAllIncluding(x=>x.Person).Where(x => x.Person.IdNumber == IdNumber && x.CreationTime >= twoMonthsAgo).OrderByDescending(x => x.CreationTime);
            return ObjectMapper.Map<List<BookingViewDto>>(historyRecord);
        }

        [HttpGet]
        public async Task<BookingDetailsDto> GetBookingDetails(Guid id)
        {
            var booking =  _bookingRepository.GetAllIncluding(x=>x.Person).Where(x=>x.Id == id).FirstOrDefault();
            var response = ObjectMapper.Map<BookingDetailsDto>(booking);
            response.CarWashOptionsName = booking.CarWashOptions.GetRefListText();
            response.StatusName = booking.Status.GetRefListText();
            return response;
        }

        [HttpPut]
        public async Task<BookingDto> UpdateAsync(BookingDto input)
        {
            var booking = _bookingRepository.GetAllIncluding(x => x.Person).Where(x => x.Id == input.Id).FirstOrDefault();
            ObjectMapper.Map(input, booking);
            await _bookingRepository.UpdateAsync(booking);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<BookingDto>(booking);
        }

        [HttpDelete]
        public async Task DeleteAsync(Guid Id)
        {
            var booking = await _bookingRepository.GetAsync(Id);
            await _bookingRepository.DeleteAsync(booking);
        }

        private string GetUniqueName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }

        private async Task<string> SwitchEventName(string status)
        {
            switch (status)
            {
                case ("Online Booking"):
                    return "Booking Confirmed";
                case ("At Spot"):
                    return "Car arrived";
                case ("Washing"):
                    return "Being attended";
                case ("Done"):
                    return "Ready to be fetched";
                default:
                    return "Thank you";

            }
        }
      
    }
}
