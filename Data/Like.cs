using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VidZNow.Models
{
    public class Like
    {
        public int Id { get; set; }

        [Required]
        public int VideoId { get; set; } // Add this property

        [Required]
        public int UserId { get; set; }

        [ForeignKey("VideoId")]
        public virtual Video Video { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
