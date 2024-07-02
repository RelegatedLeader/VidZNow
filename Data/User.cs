using System.Collections.Generic;

namespace VidZNow.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Points { get; set; }

        // Navigation properties
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CommentLike> CommentLikes { get; set; }
        public ICollection<Like> Likes { get; set; }
    }
}
