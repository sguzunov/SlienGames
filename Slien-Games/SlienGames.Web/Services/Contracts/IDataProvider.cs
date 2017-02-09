using SlienGames.Data.Models;
using System.Collections.Generic;

namespace SlienGames.Web.Services
{
    public interface IDataProvider
    {
        IEnumerable<User> GetUsers();
        IEnumerable<User> GetUserById(string id);
        IEnumerable<User> GetTopUsers(int count);
    }
}
