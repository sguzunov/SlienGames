using SlienGames.Data.Models;
using System;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using Microsoft.AspNet.Identity;
using System.IO;
using SlienGames.MVP.Manage.ManageAvatar;

namespace SlienGames.Web.Account
{
    [PresenterBinding(typeof(ManageAvatarPresenter))]
    public partial class ManageAvatar : MvpPage<ManageAvatarModel>, IManageAvatarView
    {
        public User CurrentUser { get; set; }

        public event EventHandler<IdEventArgs> GetCurrentUser;
        public event EventHandler<ManageAvatarEventArgs> SetNewAvatar;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GetCurrentUser?.Invoke(sender, new IdEventArgs(this.User.Identity.GetUserId()));
            this.CurrentUser = this.Model.User;
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (FileUpload.HasFile)
            {
                try
                {
                    var bytes = FileUpload.FileBytes;
                    var fileExtension = Path.GetExtension(FileUpload.FileName);
                    var fileName = this.User.Identity.GetUserName() + DateTime.Now.Ticks+ Path.GetFileName(FileUpload.FileName);
                    var filePath = @"\Content\Avatars\";


                    this.SetNewAvatar?.Invoke(sender, new ManageAvatarEventArgs(
                                                             fileName,
                                                             fileExtension,
                                                             filePath,
                                                             bytes,
                                                             this.User.Identity.GetUserId()
                                                             ));
                    ErrorMessage.Text = "Avatar uploaded!";
                }
                catch (Exception)
                {

                    ErrorMessage.Text = "Only allowed jpg, tif, png, and gif formats!";
                }

            }
            
        }
    }
}