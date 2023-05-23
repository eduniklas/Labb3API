using System.ComponentModel.DataAnnotations;

namespace InterestWeb.Models.DTO
{
    public class InterestListCreateDto
    {
        [Required]
        public int InterestListId { get; set; }
        [Required]
        public int FK_InterestId { get; set; }
        [Required]
        public int FK_PersonId { get; set; }
        [Required]
        public string PageUrl { get; set; }
    }
}
