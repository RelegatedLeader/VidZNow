using System;
using System.Collections.Generic;

namespace VidZNow.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int VideoId { get; set; } // Explicitly define VideoId
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual Video Video { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<CommentLike> Likes { get; set; }

        public Comment()
        {
            Likes = new List<CommentLike>();
        }
    }
}
