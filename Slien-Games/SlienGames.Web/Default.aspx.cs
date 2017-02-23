using System;
using System.Linq;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using SlienGames.MVP.Home;

namespace SlienGames.Web
{
    [PresenterBinding(typeof(HomePresenter))]
    public partial class _Default : MvpPage<HomeModel>, IHomeView
    {
        public event EventHandler GetTopReviews;
        public event EventHandler GetTopUsers;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetTopUsers?.Invoke(sender, e);
            this.GetTopReviews?.Invoke(sender, e);
            this.ListViewReviews.DataSource = this.Model.Reviews.ToList();
            this.ListViewTopPlayers.DataSource = this.Model.Users.ToList();
            this.DataBind();
        }
    }
}