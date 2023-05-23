using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InterestWeb.Models.DTO
{
    public class InterestCreateDto
    {
        [Required]
        [MaxLength(30)]
        [DisplayName("Interest Name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}
