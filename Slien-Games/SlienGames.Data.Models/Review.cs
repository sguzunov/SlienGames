using SlienGames.Data.Models.Contracts;
using System.Collections.Generic;

namespace SlienGames.Data.Models
{
    public class Review : IDbModel
    {
        private ICollection<Vote> votes;
        private ICollection<Comment> comments;

        public Review()
        {
            this.votes = new HashSet<Vote>();
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        
        public string Description { get; set; }

        public string Title { get; set; }

        public string VideoUrl { get; set; }

        public virtual User Author { get; set; }
        
        public virtual ReviewImage Picture { get; set; }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}

