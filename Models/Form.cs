using System.ComponentModel.DataAnnotations;

namespace PasswordGenerator.Models
{
    public class Form
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
