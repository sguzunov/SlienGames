using SlienGames.Data.Models.Constants;
using SlienGames.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Data.Models
{
    public class EmbeddedGame : IDbModel
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
