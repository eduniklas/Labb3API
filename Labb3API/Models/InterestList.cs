using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILabb.Models
{
    public class InterestList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InterestListId { get; set; }
        [ForeignKey("Interest")]
        public int FK_InterestId { get; set; }
        public Interest Interest { get; set; }
        [ForeignKey("Person")]
        public int FK_PersonId { get; set; }
        public Person Person { get; set; }
        public string PageUrl { get; set; }
    }
}
