using System;
using WebFormsMvp;

namespace SlienGames.MVP.ReviewMVP
{
    public interface IReviewView : IView<ReviewModel>
    {
        event EventHandler<ReviewEventArgs> GetCurrentReview;
    }
}
