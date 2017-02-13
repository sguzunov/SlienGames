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

namespace SlienGames.Web.Games
{
    [PresenterBinding(typeof(AllGamesPresenter))]
    public partial class AllGames : MvpPage<AllGamesModel>, IAllGamesView
    {
        public event EventHandler GetGames;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetGames?.Invoke(sender, e);
            this.ListGames.DataSource = this.Model.EmbeddedGames;
            this.ListGames.DataBind();
        }
    }
}