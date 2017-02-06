using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Data.Models.Constants
{
    public class ValidationConstants
    {
        public const int CommentContentMinLength = 1;
        public const int CommentContentMaxLength = 200;

        public const int FileInfoFileNameMaxLength = 50;

        public const int FileInfoFileExtensionMinLength = 3;
        public const int FileInfoFileExtensionMaxLength = 10;

        public const int GameProfileNameMinLength = 3;
        public const int GameProfileNameMaxLength = 10;

        public const int GameProfileDescriptionMinLength = 10;
        public const int GameProfileDescriptionMaxLength = 300;


    }
}
