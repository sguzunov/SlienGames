using SlienGames.Web.Models;
using SlienGames.Web.Presenters;
using SlienGames.Web.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SlienGames.Web
{
    [PresenterBinding(typeof(UserPresenter))]
    public partial class _Default : MvpPage<UserViewModel>, IUserView
    {   
        public event EventHandler MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.MyInit?.Invoke(sender, e);

            this.ListViewTopPlayers.DataSource = this.Model.Users.ToList();
            this.ListViewTopPlayers.DataBind();
        }
    }
}