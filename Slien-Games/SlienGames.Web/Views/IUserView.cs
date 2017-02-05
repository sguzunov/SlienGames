using SlienGames.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SlienGames.Web.Views
{
    public  interface IUserView : IView<UserViewModel>
    {
        event EventHandler MyInit;
    }
}
