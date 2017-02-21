using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SlienGames.Data.Models
{
    public class User : IdentityUser
    {
        private ICollection<Comment> gamesComments;
        private ICollection<GameProfile> votedGames;
        private ICollection<GameProfile> favorites;
        private ICollection<Review> reviews;
        private ICollection<Review> favoriteReviews;

        public User()
        {
            this.gamesComments = new HashSet<Comment>();
            this.votedGames = new HashSet<GameProfile>();
            this.favorites = new HashSet<GameProfile>();
            this.reviews = new HashSet<Review>();
            this.favoriteReviews = new HashSet<Review>();
        }

        public int Score { get; set; }

        public virtual ProfileImage ProfileImage { get; set; }

        public bool IsBlocked { get; set; }

        public virtual ICollection<Comment> GamesComments
        {
            get { return this.gamesComments; }
            set { this.gamesComments = value; }
        }

        public virtual ICollection<GameProfile> VotedGames
        {
            get { return this.votedGames; }
            set { this.votedGames = value; }
        }

        public virtual ICollection<GameProfile> Favorites
        {
            get { return this.favorites; }
            set { this.favorites = value; }
        }
        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }

        public virtual ICollection<Review> FavoriteReviews
        {
            get { return this.favoriteReviews; }
            set { this.favoriteReviews = value; }
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }

    }
}
