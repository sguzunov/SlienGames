using System.Data.Entity;
using SlienGames.Data;
using SlienGames.Data.Migrations;

namespace SlienGames.Web.App_Start
{
    public class DbConfig
    {
        public static void InitDatabase()
        {
            Database.SetInitializer<SlienGamesDbContext>(new MigrateDatabaseToLatestVersion<SlienGamesDbContext, Configuration>());
            SlienGamesDbContext.Create().Database.Initialize(true);
        }
    }
}