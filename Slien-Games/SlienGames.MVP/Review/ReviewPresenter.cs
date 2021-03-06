﻿using SlienGames.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SlienGames.MVP.ReviewMVP
{
    public class ReviewPresenter : Presenter<IReviewView>
    {
        private readonly IReviewsService reviewsService;

        public ReviewPresenter(IReviewView view, IReviewsService reviewsService) : base(view)
        {
            if (reviewsService == null)
            {
                throw new ArgumentNullException(nameof(reviewsService));
            }
            this.reviewsService = reviewsService;
            this.View.GetCurrentReview += View_GetCurrentReview;
        }

        private void View_GetCurrentReview(object sender, ReviewEventArgs e)
        {
            this.View.Model.Review = this.reviewsService.GetUserById(e.Id);
        }
    }
}
