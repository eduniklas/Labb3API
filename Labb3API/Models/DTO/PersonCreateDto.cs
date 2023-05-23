using System.ComponentModel.DataAnnotations;

namespace APILabb.Models.DTO
{
    public class PersonCreateDto
    {
        [Required]
        [MaxLength(40)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }
        [StringLength(15)]
        public string PhoneNumber { get; set; }
    }
}
