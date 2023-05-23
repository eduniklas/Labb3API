using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel;

namespace APILabb.Models.DTO
{
    public class InterestListUpdateDto
    {
        [Required]
        public int InterestListId { get; set; }
        [Required]
        [ForeignKey("FK_InterestId")]
        public int FK_InterestId { get; set; }
        [Required]
        [ForeignKey("FK_PersonId")]
        public int FK_PersonId { get; set; }
        [Required]
        public string PageUrl { get; set; }
    }
}
