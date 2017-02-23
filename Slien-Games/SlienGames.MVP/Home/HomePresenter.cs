using SlienGames.Data.Services.Contracts;
using System;
using System.Linq;
using WebFormsMvp;

namespace SlienGames.MVP.Home
{
    public class HomePresenter : Presenter<IHomeView>
    {
        private const string NullDependencyErrorMessage = "{0} is null!";

        private readonly IUsersService usersService;
        private readonly IReviewsService reviewsService;

        public HomePresenter(IHomeView view, IUsersService usersService, IReviewsService reviewsService) : base(view)
        {
            if (usersService == null)
            {
                throw new ArgumentNullException(string.Format(NullDependencyErrorMessage, nameof(usersService)));
            }

            if (reviewsService == null)
            {
                throw new ArgumentNullException(string.Format(NullDependencyErrorMessage, nameof(reviewsService)));

            }

            this.reviewsService = reviewsService;
            this.usersService = usersService;

            this.View.GetTopUsers += View_MyInit;
            this.View.GetTopReviews += View_GetTopReviews;
        }

        private void View_GetTopReviews(object sender, EventArgs e)
        {
            this.View.Model.Reviews = this.reviewsService.GetAll().Take(3);
        }

        private void View_MyInit(object sender, EventArgs e)
        {
            this.View.Model.Users = this.usersService.GetUsersOrderedByScore().Take(5);
        }
    }
}