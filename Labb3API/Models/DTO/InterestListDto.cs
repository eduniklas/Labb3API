using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel;

namespace APILabb.Models.DTO
{
    public class InterestListDto
    {
        [Required]
        public int InterestListId { get; set; }
        [Required]
        [ForeignKey("Interest")]
        public int FK_InterestId { get; set; }
        public Interest Interest { get; set; }
        [Required]
        [ForeignKey("Person")]
        public int FK_PersonId { get; set; }
        public Person Person { get; set; }
        [Required]
        public string PageUrl { get; set; }
    }
}
