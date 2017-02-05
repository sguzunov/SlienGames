using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SlienGames.Data.Models;
using SlienGames.Data.Contracts;

namespace SlienGames.Web.Services
{
    public class DataProvider : IDataProvider
    {
        private readonly ISlienGamesDbContext dbContext;

        public DataProvider(ISlienGamesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<User> GetTopUsers(int count)
        {
            return this.dbContext.Users.OrderBy(x => x.Score).Take(count);
        }

        public IEnumerable<User> GetUserById(string id)
        {
            return this.dbContext.Users.Where(u => u.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return this.dbContext.Users.ToList();
        }
    }
}