using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Data.Services.Contracts
{
    public interface IGamesService
    {
        IEnumerable<EmbeddedGame> GetAll();
    }
}
