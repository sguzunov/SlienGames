using System;
using WebFormsMvp;

namespace SlienGames.MVP.Manage.AddReview
{
    public interface IAddReviewView : IView<AddReviewModel>
    {
        event EventHandler<AddReviewEventArgs> SaveReview;
    }
}
