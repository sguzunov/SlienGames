using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Web.Services.Contracts
{
    public interface IUsersService
    {
        IEnumerable<User> GetAll();

    }
}
