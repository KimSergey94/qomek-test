using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models.DTO
{
    public class LoginResponseDTO
    {
        [Required]
        public UserDTO User { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
