using SlienGames.MVP.Manage.AddReview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace SlienGames.Web.Account
{
    [PresenterBinding(typeof(AddReviewPresenter))]
    public partial class AddReview : MvpPage<AddReviewModel>, IAddReviewView
    {
        public event EventHandler<AddReviewEventArgs> SaveReview;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}