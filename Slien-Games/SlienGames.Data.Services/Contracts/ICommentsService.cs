using System.Collections.Generic;

using SlienGames.Data.Models;

namespace SlienGames.Data.Services.Contracts
{
    public interface ICommentsService
    {
        Comment AddCommentToGame(int gameId, string authorUsername, string content);

        IEnumerable<Comment> GetGameComments(int gameId);
    }
}
