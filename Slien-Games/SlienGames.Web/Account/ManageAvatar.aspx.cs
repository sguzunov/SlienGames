using SlienGames.Data.Models;
using SlienGames.Web.Models;
using SlienGames.Web.Presenters;
using SlienGames.Web.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using SlienGames.Web.CustomEventArgs;
using Microsoft.AspNet.Identity;
using System.IO;

namespace SlienGames.Web.Account
{
    [PresenterBinding(typeof(UploadAvatarPresenter))]
    public partial class ManageAvatar : MvpPage<CurrentUserModel>, IUploadAvatarView
    {
        public User CurrentUser { get; set; }

        public event EventHandler<CurrentUserEventArgs> GetCurrentUser;
        public event EventHandler<UploadAvatarEventArgs> SetNewAvatar;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetCurrentUser?.Invoke(sender, new CurrentUserEventArgs(this.User.Identity.GetUserId()));
            this.CurrentUser = this.Model.User;
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                try
                {
                    //var allowedExtensions = new string[] { ".gif", ".tif", ".png", ".jpg", ".jpeg" };
                    //var fileExtension = Path.GetExtension(FileUpload.FileName);
                    //if (Array.IndexOf(allowedExtensions,fileExtension)<0)
                    //{
                    //    throw new InvalidDataException();
                    //}
                    //string fileName = Path.GetFileName(FileUpload.FileName);
                    //FileUpload.SaveAs(Server.MapPath("~/Content/Avatars/") + fileName);
                    //ErrorMessage.Text = "Avatar uploaded!"; 
                    var bytes = FileUpload.FileBytes;
                    var fileExtension = Path.GetExtension(FileUpload.FileName);
                    var fileName = this.User.Identity.GetUserName() + DateTime.Now.Ticks+ Path.GetFileName(FileUpload.FileName);
                    var filePath = @"\Content\Avatars\";


                    this.SetNewAvatar?.Invoke(sender, new UploadAvatarEventArgs(
                                                             fileName,
                                                             fileExtension,
                                                             filePath,
                                                             bytes,
                                                             this.User.Identity.GetUserId()
                                                             ));
                    ErrorMessage.Text = "Avatar uploaded!";
                }
                catch (Exception ex)
                {

                    ErrorMessage.Text = "Only allowed jpg, tif, png, and gif formats!";
                }

            }
        }
    }
}