using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;

namespace SlienGames.Data.Services
{
    public class UserService : IUsersService
    {
        private const string NullDependencyErrorMessage = "{0} is null in UsersServices!";

        private readonly IRepository<User> usersRepository;
        private readonly ISlienGamesData uow;

        public UserService(IRepository<User> usersRepository, ISlienGamesData unitOfWork)
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
        public User GetUserById(object id)
        {
            return this.usersRepository.GetById(id);
        }

        public void ChangeAvatar(string fileName, string fileExtension, string filePath, object userId)
        {
            var user = this.usersRepository.GetById(userId);
            if (user.ProfileImage == null)
            {
                user.ProfileImage = new ProfileImage();
            }
            user.ProfileImage.FileSystemUrlPath = filePath;
            user.ProfileImage.FileName = fileName;
            user.ProfileImage.FileExtension = fileExtension;
            this.usersRepository.Update(user);
            this.uow.Commit();
        }
        public IEnumerable<User> GetAll()
        {
            return this.usersRepository.GetAll();
        }
        public IEnumerable<User> GetAll(Expression<Func<User, bool>> filterExpression)
        {
            return this.usersRepository.GetAll(filterExpression);
        }

        public IEnumerable<User> GetAll<T1>(Expression<Func<User, bool>> filterExpression, Expression<Func<User, T1>> sortExpression)
        {
            return this.usersRepository.GetAll(filterExpression, sortExpression);
        }

        public IEnumerable<T2> GetAll<T1, T2>(Expression<Func<User, bool>> filterExpression, Expression<Func<User, T1>> sortExpression, Expression<Func<User, T2>> selectExpression)
        {
            return this.usersRepository.GetAll(filterExpression, sortExpression, selectExpression);
        }
    }
}
