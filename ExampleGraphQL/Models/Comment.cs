
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRentalGraphQL.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Author { get; set; }
        [ForeignKey("PostId")]
        public long PostId { get; set; }
        public Post? Post { get; set; }
        public Comment()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
