namespace SlienGames.Data.Models
{
    public class ReviewImage : FileInfo
    {
        public int? ReviewId { get; set; }

        public virtual Review Review { get; set; }
    }
}
