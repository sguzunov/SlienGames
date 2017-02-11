using System;
using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;

namespace SlienGames.Data.Services
{
    public class UserServices : IUsersServices
    {
        private const string NullDependencyErrorMessage = "{0} is null in UsersServices!";

        private readonly IRepository<User> usersRepository;
        private readonly ISlienGamesData uow;

        public UserServices(IRepository<User> usersRepository, ISlienGamesData unitOfWork)
        {
            if (usersRepository == null)
            {
                throw new ArgumentNullException(string.Format(NullDependencyErrorMessage, nameof(usersRepository)));
            }

            if (usersRepository == null)
            {
                throw new ArgumentNullException(string.Format(NullDependencyErrorMessage, nameof(unitOfWork)));
            }

            this.usersRepository = usersRepository;
            this.uow = unitOfWork;
        }

        /// <summary>
        /// Get full profile information for each user.
        /// </summary>
        /// <param name="id">Searched user's id.</param>
        /// <returns></returns>
        public User GetUserInfo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
