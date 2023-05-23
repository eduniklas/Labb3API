using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InterestWeb.Models.DTO
{
    public class InterestListUpdateDto
    {
        public int InterestListId { get; set; }
        [ForeignKey("Interest")]
        public int FK_InterestId { get; set; }
        [DisplayName("Interest")]
        public InterestDto Interest { get; set; }
        [ForeignKey("Person")]
        public int FK_PersonId { get; set; }
        [DisplayName("Name")]
        public Person Person { get; set; }
        [DisplayName("Link")]
        public string PageUrl { get; set; }
    }
}
