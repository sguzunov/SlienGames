namespace SlienGames.Data.Models
{
    public class CoverImage : FileInfo
    {
        public virtual int GameId { get; set; }

        public virtual GameProfile Game { get; set; }
    }
}
