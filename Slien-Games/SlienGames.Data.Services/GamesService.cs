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
        private IRepository<EmbeddedGame> gamesRepository;
        private ISlienGamesData unitOfWork;
        public GamesService(IRepository<EmbeddedGame> gamesRepository, ISlienGamesData unitOfWork)
        {
            this.gamesRepository = gamesRepository;
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
    }
}
