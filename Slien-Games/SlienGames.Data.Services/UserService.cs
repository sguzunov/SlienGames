using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;

namespace SlienGames.Data.Services
{
    public class UserService : IUsersService
    {
        private readonly IRepository<User> usersRepository;
        private readonly ISlienGamesData uow;

        public UserService(IRepository<User> usersRepository, ISlienGamesData unitOfWork)
        {
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
            this.CheckIfValidExtension(fileExtension);

            var user = this.usersRepository.GetById(userId);
            if (user.ProfileImage == null)
            {
                user.ProfileImage = new ProfileImage();
            }

            user.ProfileImage.FileSystemUrlPath = filePath;
            user.ProfileImage.FileName = fileName;
            user.ProfileImage.FileExtension = fileExtension;

            using (this.uow)
            {
                this.usersRepository.Update(user);
                this.uow.Commit();
            }
        }

        public void AddReview(
            string coverImageName,
            string coverImageExtension,
            string coverImageFilePath,
            object userId,
            string title,
            string videoUrl,
            string description)
        {
            this.CheckIfValidExtension(coverImageExtension);
            var user = this.usersRepository.GetById(userId);
            var review = new Review
            {
                Author = user,
                Description = description,
                Title = title,
                VideoUrl = this.GetVideoId(videoUrl)
            };
            var coverPicture = new ReviewImage
            {
                FileExtension = coverImageExtension,
                FileName = coverImageName,
                FileSystemUrlPath = coverImageFilePath,
                Review = review
            };
            review.Picture = coverPicture;
            user.Reviews.Add(review);

            using (this.uow)
            {
                this.usersRepository.Update(user);
                this.uow.Commit();
            }
        }

        public IEnumerable<User> GetAll(Expression<Func<User, bool>> filterExpression)
        {
            return this.usersRepository.GetAll(filterExpression);
        }

        // TODO: Uncomment.
        public IEnumerable<User> GetUsersOrderedByScore()
        {
            return this.usersRepository.GetAll().OrderBy(x => x.Score);
        }

        public bool CheckIfLikesAGame(string username, int gameId)
        {
            var games = this.usersRepository.GetAll(x => x.UserName == username, x => x.Favorites).SelectMany(x => x);
            return games.Any(x => x.Id == gameId);
        }

        public bool CheckIfIsBlocked(string username)
        {
            var user = this.GetAll(x => x.UserName == username).FirstOrDefault();
            if (user == null)
            {
                return false;
            }

            return user.IsBlocked;
        }

        private void CheckIfValidExtension(string extension)
        {
            var allowedExtensions = new string[] { ".gif", ".tif", ".png", ".jpg", ".jpeg" };
            if (Array.IndexOf(allowedExtensions, extension) < 0)
            {
                throw new ArgumentException("Image extension in invalid!");
            }
        }

        private string GetVideoId(string url)
        {
            var spltettedUrl = url.Split('=');
            return spltettedUrl[1];
        }
    }
}
