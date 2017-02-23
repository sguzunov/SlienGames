 using SlienGames.Data.Models.Constants;

namespace SlienGames.Data.Models
{
    public class ProfileImage : FileInfo
    {
        public ProfileImage()
        {           
        }
        public virtual int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
