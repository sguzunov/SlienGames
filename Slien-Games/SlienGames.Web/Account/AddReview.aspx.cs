using Microsoft.AspNet.Identity;
using SlienGames.MVP.Manage.AddReview;
using System;
using System.Collections.Generic;
using System.IO;
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
            if (PictureUpload.HasFile)
            {
                try
                {
                    var bytes = PictureUpload.FileBytes;
                    var fileExtension = Path.GetExtension(PictureUpload.FileName);
                    var fileName = this.User.Identity.GetUserName() + DateTime.Now.Ticks + Path.GetFileName(PictureUpload.FileName);
                    var filePath = @"\Content\ReviewsImages\";
                    var title = this.TextBoxTitle.Text;
                    var videoUrl = this.TextBoxVideoUrl.Text;
                    var description = this.description.Value;

                    this.SaveReview?.Invoke(sender, new AddReviewEventArgs(
                        fileName,
                        fileExtension,
                        filePath,
                        bytes,
                        this.User.Identity.GetUserId(),
                        title,
                        videoUrl,
                        description));
                }
                catch(Exception)
                {
                    Server.Transfer("/Errors/ErrorPage");
                }

                Response.Redirect("/Account/Manage");
            }
        }
    }
}