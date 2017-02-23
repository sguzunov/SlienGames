using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SlienGames.Data.Models.Constants;
using SlienGames.Data.Models.Contracts;

namespace SlienGames.Data.Models
{
    public class GameDetails : IDbModel
    {
        private ICollection<GameRating> ratings;
        private ICollection<Comment> comments;
        private ICollection<User> usersVotedThisGame;

        public GameDetails()
        {
            this.ratings = new HashSet<GameRating>();
            this.comments = new HashSet<Comment>();
            this.usersVotedThisGame = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(ValidationConstants.GameProfileNameMinLength)]
        [MaxLength(ValidationConstants.GameProfileNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(ValidationConstants.GameProfileDescriptionMinLength)]
        [MaxLength(ValidationConstants.GameProfileDescriptionMaxLength)]
        public string Description { get; set; }

        public bool IsPublished { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual CoverImage CoverImage { get; set; }

        public virtual ExternalGameResource ExternalResource { get; set; }

        public virtual int Votes { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<User> UsersVotedThisGame
        {
            get { return this.usersVotedThisGame; }
            set { this.usersVotedThisGame = value; }
        }

        public virtual ICollection<GameRating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}
