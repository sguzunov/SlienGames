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
        private IRepository<EmbeddedGame> usersRepository;
        private ISlienGamesData unitOfWork;
        public GamesService(IRepository<EmbeddedGame> usersRepository, ISlienGamesData unitOfWork)
        {
            this.usersRepository = usersRepository;
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<EmbeddedGame> GetAll()
        {
            return this.usersRepository.GetAll();
        }
    }
}
