using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SlienGames.Data.Models
{
    public class EmbeddedGame
    {
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;

        public EmbeddedGame()
        {
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string GameContent { get; set; }

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
