using System.Collections.Generic;
using System.Linq;

using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;

namespace SlienGames.Data.Services
{
    public class GamesService : IGamesService
    {
        private readonly IRepository<User> usersRepository;
        private readonly IRepository<GameDetails> gamesRepository;
        private readonly ISlienGamesData unitOfWork;

        public GamesService(
            IRepository<GameDetails> gamesRepository,
            IRepository<GameRating> gamesRatingsRepository,
            IRepository<User> usersRepository,
            ISlienGamesData unitOfWork)
        {
            this.gamesRepository = gamesRepository;
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

        public bool LikeGame(int gameId, string username)
        {
            var user = this.usersRepository.GetAll<User>(x => x.UserName == username, null, x => x.Favorites).First();

            if (user.Favorites.Any(x => x.Id == gameId)) return false;

            using (this.unitOfWork)
            {
                var game = this.gamesRepository.GetById(gameId);
                user.Favorites.Add(game);
                this.unitOfWork.Commit();
            }

            return true;
        }
    }
}
