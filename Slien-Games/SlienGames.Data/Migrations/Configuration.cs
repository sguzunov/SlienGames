using System.Data.Entity.Migrations;

namespace SlienGames.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SlienGamesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
    }
}
