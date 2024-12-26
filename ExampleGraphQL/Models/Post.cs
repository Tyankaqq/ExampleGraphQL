using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalGraphQL.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
        public DateTime? CreateAt { get; set; }
        [Required]
        public string? Author { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Post()
        {
            
            CreateAt = DateTime.Now;
        }
    }
}
