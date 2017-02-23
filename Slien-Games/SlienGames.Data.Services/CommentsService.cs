using System;

using SlienGames.Data.Services.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Contracts;
using System.Linq;
using System.Collections.Generic;

namespace SlienGames.Data.Services
{
    public class CommentsService : ICommentsService
    {
        private const int CommentMaxLenght = 200;

        private readonly IRepository<User> usersRepository;
        private readonly IRepository<Comment> commentsRepository;
        private readonly IRepository<GameDetails> gamesRepository;
        private readonly ISlienGamesData unitOfWork;

        public CommentsService(
            IRepository<User> usersRepository,
            IRepository<Comment> commentsRepository,
            IRepository<GameDetails> gamesRepository,
            ISlienGamesData unitOfWork)
        {
            this.usersRepository = usersRepository;
            this.commentsRepository = commentsRepository;
            this.gamesRepository = gamesRepository;
            this.unitOfWork = unitOfWork;
        }

        public Comment AddCommentToGame(int gameId, string authorUsername, string content)
        {
            if (content.Length > CommentMaxLenght)
            {
                throw new ArgumentException("Comment content is too large!");
            }

            var game = this.gamesRepository.GetById(gameId);
            var author = this.usersRepository.GetAll(x => x.UserName == authorUsername).FirstOrDefault();

            if (game == null)
            {
                throw new ArgumentException($"Game with id = {gameId} is not found!");
            }

            if (author == null)
            {
                throw new ArgumentException($"Game with username = {authorUsername} is not found!");
            }

            var comment = new Comment
            {
                Content = content,
                AuthorId = Guid.Parse(author.Id),
                Author = author,
                GameDetails = game,
                PostedOn = DateTime.Now
            };

            using (this.unitOfWork)
            {
                game.Comments.Add(comment);
                this.unitOfWork.Commit();
            }

            return comment;
        }

        public IEnumerable<Comment> GetGameComments(int gameId)
        {
            var comments = this.commentsRepository.GetAll<Comment>(x => x.GameDetailsId == gameId, null, x => x.Author);
            return comments;
        }
    }
}
