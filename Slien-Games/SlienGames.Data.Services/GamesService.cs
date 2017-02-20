using System.Collections.Generic;
using System.Linq;

using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;

namespace SlienGames.Data.Services
{
    public class GamesService : IGamesService
    {
        private readonly IRepository<EmbeddedGame> gamesRepository;
        private readonly IRepository<GameProfile> gameProfileRepository;
        private readonly ISlienGamesData unitOfWork;

        public GamesService(IRepository<EmbeddedGame> gamesRepository, IRepository<GameProfile> gameProfileRepository, ISlienGamesData unitOfWork)
        {
            this.gamesRepository = gamesRepository;
            this.gameProfileRepository = gameProfileRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<EmbeddedGame> GetAll()
        {
            return this.gamesRepository.GetAll();
        }

        public EmbeddedGame GetById(object id)
        {
            return this.gamesRepository.GetById(id);
        }

        public GameProfile GetDetailsWithComments(string gameName)
        {
            var gameDetails = this.gameProfileRepository.GetAll<GameProfile>(
                x => x.Name == gameName && x.IsPublished,
                null,
                x => x.Comments).FirstOrDefault();

            return gameDetails;
        }
    }
}
