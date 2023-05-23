using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APILabb.Models
{
    public class InterestList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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
