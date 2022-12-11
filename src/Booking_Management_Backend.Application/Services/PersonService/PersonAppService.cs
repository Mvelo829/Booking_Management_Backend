using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Localization;
using Abp.Runtime.Session;
using Abp.Runtime.Validation;
using AutoMapper;
using Booking_Management_Backend.Authorization.Users;
using Booking_Management_Backend.Domain;
using Booking_Management_Backend.Services.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Services.PersonService
{
    public class PersonAppService : ApplicationService, IPersonAppService
    {
        private readonly UserManager _userManager;
        private readonly IRepository<Person, Guid> _PersonRepository;
        public PersonAppService(UserManager userManager, IRepository<Person, Guid> PersonRepository)
        {
            _userManager = userManager;
            _PersonRepository = PersonRepository;
        }

        [HttpPost]
        public async Task<PersonDto> CreateAsync(PersonDto input)
        {
            var person = ObjectMapper.Map<Person>(input);
            await _PersonRepository.InsertAsync(person);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<PersonDto>(person);
        }

        [HttpGet]
        public async Task<List<PersonDto>> GetAllAsync()
        {
            var person = await _PersonRepository.GetAllListAsync();
            if (person == null)
                throw new AbpValidationException("", new List<ValidationResult> { new ValidationResult($"No Person Found") });

            return ObjectMapper.Map<List<PersonDto>>(person);
        }

        [HttpGet]
        public async Task<PersonDto> GetAsync(Guid Id)
        {
            var person = await _PersonRepository.GetAsync(Id);
            if (person == null)
                throw new AbpValidationException("", new List<ValidationResult> { new ValidationResult($"No Person Found") });
            return ObjectMapper.Map<PersonDto>(person);
        }

        [HttpPut]
        public async Task<PersonDto> UpdateAsync(PersonDto input)
        {
            var person = await _PersonRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, person);
            await _PersonRepository.UpdateAsync(person);
            CurrentUnitOfWork.SaveChanges();
            return ObjectMapper.Map<PersonDto>(person);
        }

        [HttpDelete]
        public async Task DeleteAsync(Guid id)
        {
            await _PersonRepository.DeleteAsync(id);
        }
    }
}
