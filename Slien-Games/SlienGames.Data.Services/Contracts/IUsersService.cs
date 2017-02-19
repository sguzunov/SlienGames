using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Data.Services.Contracts
{
    public interface IUsersService
    {
        IEnumerable<User> GetAll();

        IEnumerable<User> GetAll(Expression<Func<User, bool>> filterExpression);

        IEnumerable<User> GetAll<T1>(Expression<Func<User, bool>> filterExpression, Expression<Func<User, T1>> sortExpression);

        IEnumerable<T2> GetAll<T1, T2>(Expression<Func<User, bool>> filterExpression, Expression<Func<User, T1>> sortExpression, Expression<Func<User, T2>> selectExpression);

        User GetUserById(object id);

        void ChangeAvatar(string fileName, string fileExtension, string filePath, object userId);

        void AddReview(
            string coverImageName,
            string coverImageExtension,
            string coverImageFilePath,
            object userId,
            string title,
            string videoUrl,
            string description);

    }
}
