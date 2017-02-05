using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using  SlienGames.Data.Models;

namespace SlienGames.Web.Models
{
    public class UserViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}