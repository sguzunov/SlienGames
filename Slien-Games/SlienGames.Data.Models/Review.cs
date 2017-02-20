using System.Collections.Generic;

namespace SlienGames.Data.Models
{
    public class Review
    {
        private ICollection<Comment> comments;

        public Review()
        {
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public int Rating { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string VideoUrl { get; set; }

        public virtual User Author { get; set; }

        public virtual ReviewImage Picture { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}

