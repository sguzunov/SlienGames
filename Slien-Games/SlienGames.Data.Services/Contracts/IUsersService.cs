using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SlienGames.Data.Services.Contracts
{
    public interface IUsersService
    {
        IEnumerable<User> GetAll(Expression<Func<User, bool>> filterExpression);

        IEnumerable<User> GetUsersOrderedByScore();

        User GetUserById(object id);

        void ChangeAvatar(string fileName, string fileExtension, string filePath, object userId);

        bool CheckIfIsBlocked(string username);

        bool CheckIfLikesAGame(string username, int gameId);

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
