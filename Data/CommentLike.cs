using System.ComponentModel.DataAnnotations.Schema;

namespace VidZNow.Models
{
    public class CommentLike
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("CommentId")]
        public Comment Comment { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
