using System.Collections.Generic;
using System.Linq;

using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;
using System;

namespace SlienGames.Data.Services
{
    public class GamesService : IGamesService
    {
        private readonly IRepository<User> usersRepository;
        private readonly IRepository<GameDetails> gamesRepository;
        private readonly IRepository<GameRating> gamesRatingsRepository;
        private readonly ISlienGamesData unitOfWork;

        public GamesService(
            IRepository<GameDetails> gamesRepository,
            IRepository<GameRating> gamesRatingsRepository,
            IRepository<User> usersRepository,
            ISlienGamesData unitOfWork)
        {
            this.gamesRepository = gamesRepository;
            this.gamesRatingsRepository = gamesRatingsRepository;
            this.usersRepository = usersRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<GameDetails> GetAll()
        {
            return this.gamesRepository.GetAll();
        }

        public GameDetails GetById(object id)
        {
            return this.gamesRepository.GetById(id);
        }

        public GameDetails GetDetailsWithComments(string gameName)
        {
            var gameDetails = this.gamesRepository.GetAll<GameDetails>(
                x => x.Name == gameName,
                null,
                x => x.Comments).FirstOrDefault();

            return gameDetails;
        }

        public void RateGame(int gameId, Guid userId, int ratingValue)
        {
            var user = this.usersRepository.GetById(userId);
            var game = this.gamesRepository.GetById(gameId);

            var rating = new GameRating
            {
                User = user,
                Game = game,
                Value = ratingValue
            };

            using (this.unitOfWork)
            {
                this.gamesRatingsRepository.Add(rating);
                this.unitOfWork.Commit();
            }
        }
    }
}
