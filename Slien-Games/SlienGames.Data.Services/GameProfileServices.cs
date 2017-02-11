using System.Linq;

using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;

namespace SlienGames.Data.Services
{
    public class GameProfileServices : IGameProfileServices
    {
        private readonly IRepository<GameProfile> gameProfileRepository;

        public GameProfileServices(IRepository<GameProfile> gameProfileRepository)
        {
            this.gameProfileRepository = gameProfileRepository;
        }

        public GameProfile GetProfileInfoByName(string gameName)
        {
            var profile = this.gameProfileRepository.GetAll(x => x.Name == gameName).FirstOrDefault();
            return profile;
        }
    }
}
