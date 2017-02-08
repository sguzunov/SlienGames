using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using SlienGames.Data.Models.Contracts;

namespace SlienGames.Data.Models
{
    public class User : IdentityUser, IDbModel
    {
        private ICollection<Comment> gamesComments;
        private ICollection<GameProfile> votedGames;

        public User()
        {
            this.gamesComments = new HashSet<Comment>();
            this.votedGames = new HashSet<GameProfile>();
        }

        public int Score { get; set; }

        public virtual ProfileImage ProfileImage { get; set; }

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

        int IDbModel.Id { get; set; }

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
