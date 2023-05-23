using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace APILabb.Models.DTO
{
    public class PersonDto
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
        public virtual ICollection<Interest> Interests { get; set; }

    }
}
