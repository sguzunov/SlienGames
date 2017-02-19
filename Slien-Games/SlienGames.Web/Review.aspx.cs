using SlienGames.MVP.Review;
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
    [PresenterBinding(typeof(ReviewPresenter))]
    public partial class Review : MvpPage<ReviewModel>, IReviewView
    {
        public SlienGames.Data.Models.Review CurrentReview { get; set; }

        public event EventHandler<ReviewEventArgs> GetCurrentReview;

        protected void Page_Load(object sender, EventArgs e)
        {
            var reviewId = Request.QueryString["id"];

            GetCurrentReview?.Invoke(sender, new ReviewEventArgs(int.Parse(reviewId)));
            this.CurrentReview = this.Model.Review;
        }
    }
}