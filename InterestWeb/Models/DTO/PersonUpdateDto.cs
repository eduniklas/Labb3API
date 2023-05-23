using System.ComponentModel.DataAnnotations;

namespace InterestWeb.Models.DTO
{
    public class PersonUpdateDto
    {
        public int PersonId { get; set; }
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
