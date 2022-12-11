using Abp.Application.Services;
using Booking_Management_Backend.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Management_Backend.Services.PersonService
{
    public interface IPersonAppService : IApplicationService
    {
        Task<PersonDto> CreateAsync(PersonDto input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<PersonDto> GetAsync(Guid Id);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<PersonDto>> GetAllAsync();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PersonDto> UpdateAsync(PersonDto input);
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task DeleteAsync(Guid id);
    }
}
