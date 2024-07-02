using System.Collections.Generic;

namespace VidZNow.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        // Additional properties
        public int CommentsCount { get; set; }
        public int LikesCount { get; set; }

        // Navigation properties
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Comment> TopComments { get; set; }

        public Video()
        {
            Comments = new List<Comment>();
            Likes = new List<Like>();
            TopComments = new List<Comment>();
        }
    }
}
