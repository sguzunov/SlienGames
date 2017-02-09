using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Web.CustomEventArgs;
using SlienGames.Web.Views;
using WebFormsMvp;

namespace SlienGames.Web.Presenters
{
    public class CurrentUserPresenter : Presenter<ICurrentUserView>
    {
        private IRepository<User> dataProvider;

        public CurrentUserPresenter(ICurrentUserView view, IRepository<User> dataProvider)
            : base(view)
        {
            this.dataProvider = dataProvider;
            this.View.MyInit += View_MyInit;
        }

        private void View_MyInit(object sender, CurrentUserEventArgs e)
        {
            this.View.Model.User = this.dataProvider.GetById(e.Id);
        }
    }
}