namespace SlienGames.MVP.Games.Details
{
    public class NewCommentEventArgs
    {
        public NewCommentEventArgs(int gameId, string authorUsername, string commentContent)
        {
            this.GameId = gameId;
            this.AuthorUsername = authorUsername;
            this.CommentContent = commentContent;
        }

        public int GameId { get; set; }

        public string AuthorUsername { get; set; }

        public string CommentContent { get; set; }
    }
}