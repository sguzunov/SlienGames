using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;
using SlienGames.Web.CustomEventArgs;
using SlienGames.Web.Views;
using System;
using System.IO;
using WebFormsMvp;

namespace SlienGames.Web.Presenters
{
    public class UploadAvatarPresenter : Presenter<IUploadAvatarView>
    {
        private readonly IUsersService usersService;
        private readonly IFileSaver fileSaver;
        public UploadAvatarPresenter(
            IUploadAvatarView view,
            IUsersService usersService,
            IFileSaver fileSaver)
            : base(view)
        {
            this.usersService = usersService;
            this.fileSaver = fileSaver;

            this.View.GetCurrentUser += View_GetCurrentUser;
            this.View.SetNewAvatar += View_SetNewAvatar;
        }

        private void View_SetNewAvatar(object sender, UploadAvatarEventArgs e)
        {
            var allowedExtensions = new string[] { ".gif", ".tif", ".png", ".jpg", ".jpeg" };
            if (Array.IndexOf(allowedExtensions, e.FileExtension) < 0)
            {
                throw new InvalidDataException();
            }
            //var user = this.dataProvider.GetById(e.UserId);
            //if (user.ProfileImage == null)
            //{
            //    user.ProfileImage = new ProfileImage();
            //}
            //user.ProfileImage.FileSystemUrlPath = e.FilePath;
            //user.ProfileImage.FileName = e.FileName;
            //user.ProfileImage.FileExtension = e.FileExtension;
            //dataProvider.Update(user);
            //unitOfWork.Commit();
            usersService.ChangeAvatar(e.FileName, e.FileExtension, e.FilePath, e.UserId);
            fileSaver.SaveFile(e.FilePath + e.FileName, e.AllBytes);
        }

        private void View_GetCurrentUser(object sender, CustomEventArgs.CurrentUserEventArgs e)
        {
            this.View.Model.User = this.usersService.GetUserById(e.Id);
        }
    }
}