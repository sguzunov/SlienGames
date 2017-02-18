using System;

using WebFormsMvp;
using WebFormsMvp.Web;
using SlienGames.MVP.GameInfo;

namespace SlienGames.Web.GameInfo
{
    [PresenterBinding(typeof(GameInfoPresenter))]
    public partial class GameInfo : MvpPage<GameInfoModel>, IGameInfoView
    {
        public event EventHandler<GetGameInfoEventArgs> MyInit;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if event has methods subscribed!!!

            string gameName = this.Request.Params["name"];
            this.MyInit(this, new GetGameInfoEventArgs(gameName));


        }
    }
}