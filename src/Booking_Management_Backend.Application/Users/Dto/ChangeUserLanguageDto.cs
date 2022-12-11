using System.ComponentModel.DataAnnotations;

namespace Booking_Management_Backend.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}