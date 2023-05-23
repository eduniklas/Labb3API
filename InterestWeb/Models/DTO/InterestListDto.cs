using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InterestWeb.Models.DTO
{
    public class InterestListDto
    {
        [Required]
        public int InterestListId { get; set; }
        [Required]
        [ForeignKey("Interest")]
        public int FK_InterestId { get; set; }
        [DisplayName("Interest")]
        public InterestDto Interest { get; set; }
        [Required]
        [ForeignKey("Person")]
        public int FK_PersonId { get; set; }
        [DisplayName("Name")]
        public Person Person { get; set; }
        [Required]
        [DisplayName("Link")]
        public string PageUrl { get; set; }
    }
}
