using System;
using WebFormsMvp;

namespace SlienGames.MVP.Review
{
    public interface IReviewView : IView<ReviewModel>
    {
        event EventHandler<ReviewEventArgs> GetCurrentReview;
    }
}
