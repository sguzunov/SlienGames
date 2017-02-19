using SlienGames.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SlienGames.MVP.Manage.AddReview
{
    public class AddReviewPresenter : Presenter<IAddReviewView>
    {
        private readonly IUsersService usersService;
        private readonly IFileSaver fileSaver;
        public AddReviewPresenter(IAddReviewView view, IUsersService usersService, IFileSaver fileSaver) : base(view)
        {
            this.usersService = usersService;
            this.fileSaver = fileSaver;
            this.View.SaveReview += View_SaveReview;
        }

        private void View_SaveReview(object sender, AddReviewEventArgs e)
        {
            this.usersService.AddReview(
                e.CoverImageName,
                e.CoverImageExtension,
                e.CoverImagePath,
                e.UserId,
                e.Title, 
                e.VideoUrl,
                e.Description);

            this.fileSaver.SaveFile(e.CoverImagePath + e.CoverImageName, e.CoverImageAllBytes);
        }
    }
}
