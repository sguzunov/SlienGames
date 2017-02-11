using System;
using System.Collections.Generic;
using SlienGames.Data.Contracts;
using SlienGames.Data.Models;
using SlienGames.Data.Services.Contracts;
using SlienGames.Web.CustomEventArgs;
using SlienGames.Web.Views;

using WebFormsMvp;

namespace SlienGames.Web.Presenters
{
    public class GameInfoPresenter : Presenter<IGameInfoView>
    {
        private const string DependencyIsNullErrorMessage = "{0} is null in {1}!";

        private readonly IGameInfoView view;
        private readonly IGameProfileServices gameProfileServices;

        public GameInfoPresenter(IGameInfoView view, IGameProfileServices gameProfileServices, ISlienGamesData uow) : base(view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(string.Format(DependencyIsNullErrorMessage, nameof(view), this.GetType().Name));
            }

            if (gameProfileServices == null)
            {
                throw new ArgumentNullException(string.Format(DependencyIsNullErrorMessage, nameof(gameProfileServices), this.GetType().Name));
            }

            this.view = view;
            this.gameProfileServices = gameProfileServices;

            this.view.MyInit += this.Load;
        }

        private void Load(object sender, GetGameInfoEventArgs args)
        {
            string gameName = args.GameName;

            //if (gameName == null)
            //{
            //    // TODO: Handle correctly this ERROR!
            //    throw new ArgumentNullException();
            //}

            var gameProfile = this.gameProfileServices.GetProfileInfoByName(gameName);
            //this.view.Model.GameName = gameProfile.Name;
            //this.view.Model.GameDescription = gameProfile.Description;
            //this.view.Model.CoverImageFileSystemPath = gameProfile.CoverImage.FileSystemUrlPath;
            //this.view.Model.Comments = gameProfile.Comments;

            this.view.Model.GameName = "Tanks";
            this.view.Model.GameDescription = "Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна. Популяризиран е през 60те години на 20ти век със издаването на Letraset листи, съдържащи Lorem Ipsum пасажи, популярен е и в наши дни във софтуер за печатни издания като Aldus PageMaker, който включва различни версии на Lorem Ipsum.";
            this.view.Model.CoverImageFileSystemPath = "/Uploaded_Images/Covers/1.jpg";
            this.view.Model.Comments = new List<Comment>
            {
                new Comment
                {
                    Content = "Here i am again!",
                    PostedOn = DateTime.Now,
                    Author = new User { UserName = "Pesho" }
                },
                new Comment
                {
                    Content = "Lorem Ipsum е елементарен примерен текст, използван в печатарската и типографската индустрия. Lorem Ipsum е индустриален стандарт от около 1500 година, когато неизвестен печатар взема няколко печатарски букви и ги разбърква, за да напечата с тях книга с примерни шрифтове. Този начин не само е оцелял повече от 5 века, но е навлязъл и в публикуването на електронни издания като е запазен почти без промяна.",
                    PostedOn = DateTime.Now,
                    Author = new User { UserName = "Ivan" }
                }
            };
        }
    }
}