using System.Collections.Generic;

using SlienGames.Data.Models;

namespace SlienGames.Data.Services.Contracts
{
    public interface ICommentsService
    {
        void AddCommentToGame(int gameId, string authorUsername, string content);

        IEnumerable<Comment> GetGameComments(int gameId);
    }
}
