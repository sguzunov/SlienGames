using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Web.Services.Contracts;
using SlienGames.Web.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebFormsMvp;

namespace SlienGames.Web.Presenters
{
    public class UploadAvatarPresenter : Presenter<IUploadAvatarView>
    {
        private readonly IRepository<User> dataProvider;
        private readonly IFileSaver fileSaver;
        private readonly ISlienGamesData unitOfWork;
        public UploadAvatarPresenter(
            IUploadAvatarView view, 
            IRepository<User> dataProvider, 
            IFileSaver fileSaver,
            ISlienGamesData unitOfWork) 
            : base(view)
        {
            this.dataProvider = dataProvider;
            this.fileSaver = fileSaver;
            this.unitOfWork = unitOfWork;

            this.View.GetCurrentUser += View_GetCurrentUser;
            this.View.SetNewAvatar += View_SetNewAvatar;
        }

        private void View_SetNewAvatar(object sender, CustomEventArgs.UploadAvatarEventArgs e)
        {
            var allowedExtensions = new string[] { ".gif", ".tif", ".png", ".jpg", ".jpeg" };           
            if (Array.IndexOf(allowedExtensions, e.FileExtension) < 0)
            {
                throw new InvalidDataException();
            }
            var user = this.dataProvider.GetById(e.UserId);
            if (user.ProfileImage == null)
            {
                user.ProfileImage = new ProfileImage();
            }
            user.ProfileImage.FileSystemUrlPath = e.FilePath;
            user.ProfileImage.FileName = e.FileName;
            user.ProfileImage.FileExtension = e.FileExtension;
            dataProvider.Update(user);
            unitOfWork.Commit();

            fileSaver.SaveFile(e.FilePath + e.FileName, e.AllBytes);
        }

        private void View_GetCurrentUser(object sender, CustomEventArgs.CurrentUserEventArgs e)
        {
            this.View.Model.User = this.dataProvider.GetById(e.Id);
        }
    }
}