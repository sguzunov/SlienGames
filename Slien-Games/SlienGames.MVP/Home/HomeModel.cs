
using System.Collections.Generic;
using  SlienGames.Data.Models;

namespace SlienGames.MVP.Home
{
    public class HomeModel
    {
        public IEnumerable<User> Users { get; set; }

        public IEnumerable<Review> Reviews { get; set; }
    }
}