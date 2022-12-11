using Abp.Application.Services;
using Abp.Domain.Repositories;
using Booking_Management_Backend.Domain;
using Booking_Management_Backend.Services.Dtos;
using Booking_Management_Backend.Services.PersonService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        public async Task<BookingDto> CreateAsync(BookingDto input)
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
        public async Task<BookingDetailsDto> GetBookingDetails(Guid id)
        {
            var booking =  _bookingRepository.GetAllIncluding(x=>x.Person).Where(x=>x.Id == id).FirstOrDefault();
            return ObjectMapper.Map<BookingDetailsDto>(booking);
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

    }
}
