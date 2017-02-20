using SlienGames.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlienGames.Data.Models;
using SlienGames.Data.Contracts;

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

        public GameProfile GetDetailsByName(string gameName)
        {
            var gameDetails = this.gameProfileRepository.GetAll<GameProfile, GameProfile>(
                x => x.Name == gameName,
                null,
                x => new GameProfile
                {
                    Name = x.Name,
                    Description = x.Description,
                    Comments = x.Comments,
                }).FirstOrDefault();

            return gameDetails;
        }
    }
}
