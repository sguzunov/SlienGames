using SlienGames.Web.Services;
using SlienGames.Web.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace SlienGames.Web.Presenters
{
    public class UserPresenter : Presenter<IUserView>
    {
        private readonly IDataProvider dataProvider; 

        public UserPresenter(IUserView view, IDataProvider dataProvider) : base(view)
        {
            this.dataProvider = dataProvider;

            this.View.MyInit += View_MyInit;
        }

        private void View_MyInit(object sender, EventArgs e)
        {
            this.View.Model.Users = this.dataProvider.GetTopUsers(5);
        }
    }
}