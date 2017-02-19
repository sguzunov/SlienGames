using SlienGames.Data.Services.Contracts;
using WebFormsMvp;

namespace SlienGames.MVP.Manage.ManageAvatar
{
    public class ManageAvatarPresenter : Presenter<IManageAvatarView>
    {
        private IUsersService usersService;
        private readonly IFileSaver fileSaver;

        public ManageAvatarPresenter(IManageAvatarView view, IUsersService usersService, IFileSaver fileSaver)
            : base(view)
        {
            this.usersService = usersService;
            this.fileSaver = fileSaver;
            this.View.GetCurrentUser += View_MyInit;
            this.View.SetNewAvatar += View_SetNewAvatar;
        }

        private void View_SetNewAvatar(object sender, ManageAvatarEventArgs e)
        {
            usersService.ChangeAvatar(e.FileName, e.FileExtension, e.FilePath, e.UserId);
            fileSaver.SaveFile(e.FilePath + e.FileName, e.AllBytes);
        }

        private void View_MyInit(object sender, IdEventArgs e)
        {
            this.View.Model.User = this.usersService.GetUserById(e.Id);
        }
    }
}