namespace SlienGames.Data.Models
{
    public class CoverImage : FileInfo
    {
        public int? GameId { get; set; }

        public virtual GameProfile Game { get; set; }
    }
}
