using SlienGames.Data.Models.Constants;

namespace SlienGames.Data.Models
{
    public class ProfileImage : FileInfo
    {
        public ProfileImage()
        {
            this.FileExtension = DefaultValueConstants.DefaultFileExtension;
            this.FileName = DefaultValueConstants.DefaultFileName;
            this.FileSystemUrlPath = DefaultValueConstants.DefaultFyleSystemUrlPath;
        }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
