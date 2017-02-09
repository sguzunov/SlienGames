using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Web.Services
{
    public interface IDataProvider
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUserById(string id);
        IEnumerable<User> GetTopUsers(int count);
    }
}
