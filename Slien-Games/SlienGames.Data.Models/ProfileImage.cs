namespace SlienGames.Data.Models
{
    public class ProfileImage : FileInfo
    {
        public int? UserId { get; set; }

        public virtual User User { get; set; }
    }
}
