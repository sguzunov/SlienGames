using SlienGames.MVP.Games;
using System;
using System.Linq;
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
            
            //this.ListGames.DataSource = this.Model.Games;
            //this.ListGames.DataBind();
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<SlienGames.Data.Models.GameDetails> ListGames_GetData()
        {
            this.GetGames?.Invoke(this, null);

            return this.Model.Games.AsQueryable();
        }
    }
}