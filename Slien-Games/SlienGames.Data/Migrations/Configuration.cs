using System.Data.Entity.Migrations;

using SlienGames.Data.Models;
using System;

namespace SlienGames.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SlienGamesDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SlienGamesDbContext context)
        {
            base.Seed(context);

            // = "/Content/EmbeddedGames/Images/flipdiving.jpg"
            context.GamesDetails.AddOrUpdate(x => x.Id,
                new GameDetails
                {
                    Id = 1,
                    Name = "Flip Diving",
                    CreatedOn = DateTime.Now,
                    Description = "Funnnnnnnnnn!",
                    ExternalResource = new ExternalGameResource
                    {
                        Id = 1,
                        GameContent = "<div class='miniclip-game-embed' data-game-name='flip-diving' data-theme='0' data-width='488' data-height='670' data-language='en'><a href='http://www.miniclip.com/games/flip-diving/'>Play Flip Diving</a></div>",

                    },
                    CoverImage = new CoverImage
                    {
                        Id = 1,
                        FileExtension = "jpg",
                        FileName = "flipdiving",
                        FileSystemUrlPath = "/Content/EmbeddedGames/Images/flipdiving.jpg",
                        GameId = 1
                    }
                },
                new GameDetails
                {
                    Id = 2,
                    Name = "Basketball Stars",
                    CreatedOn = DateTime.Now,
                    Description = "Funnnnnnnnnn!",
                    ExternalResource = new ExternalGameResource
                    {
                        Id = 2,
                        GameContent = "<div class='miniclip-game-embed' data-game-name='basketball-stars' data-theme='0' data-width='365' data-height='650' data-language='en'><a href='http://www.miniclip.com/games/basketball-stars/'>Play Basketball Stars</a></div>",

                    },
                    CoverImage = new CoverImage
                    {
                        Id = 2,
                        FileExtension = "jpg",
                        FileName = "8ballpool",
                        FileSystemUrlPath = "/Content/EmbeddedGames/Images/8ballpool.jpg",
                        GameId = 2
                    }
                },
                new GameDetails
                {
                    Id = 3,
                    Name = "8 Ball Pool",
                    CreatedOn = DateTime.Now,
                    Description = "Funnnnnnnnnn!",
                    ExternalResource = new ExternalGameResource
                    {
                        Id = 3,
                        GameContent = "<div class='miniclip-game-embed' data-game-name='8-ball-pool-multiplayer' data-theme='0' data-width='750' data-height='520' data-language='en'><a href='http://www.miniclip.com/games/8-ball-pool-multiplayer/'>Play 8 Ball Pool</a></div>",

                    },
                    CoverImage = new CoverImage
                    {
                        Id = 3,
                        FileExtension = "jpg",
                        FileName = "8ballpool",
                        FileSystemUrlPath = "/Content/EmbeddedGames/Images/8ballpool.jpg",
                        GameId = 3
                    }
                },
                 new GameDetails
                 {
                     Id = 4,
                     Name = "Bow Master",
                     CreatedOn = DateTime.Now,
                     Description = "Funnnnnnnnnn!",
                     ExternalResource = new ExternalGameResource
                     {
                         Id = 4,
                         GameContent = "<div class='miniclip-game-embed' data-game-name='bow-master-halloween' data-theme='0'  data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/bow-master-halloween/'>Play Bow Master Halloween</a></div>",

                     },
                     CoverImage = new CoverImage
                     {
                         Id = 4,
                         FileExtension = "jpg",
                         FileName = "bowmaster",
                         FileSystemUrlPath = "/Content/EmbeddedGames/Images/bowmaster.jpg",
                         GameId = 4
                     }
                 }
                //new EmbeddedGame
                //{
                //    Id = 4,
                //    Name = "Bow Master",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='bow-master-halloween' data-theme='0'  data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/bow-master-halloween/'>Play Bow Master Halloween</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/bowmaster.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 5,
                //    Name = "Stealth Sniper",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='stealth-sniper' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/stealth-sniper/'>Play Stealth Sniper</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/stealthsniper.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 6,
                //    Name = "MiniSoccer",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='minisoccer' data-theme='0' data-width='800' data-height='700' data-language='en'><a href='http://www.miniclip.com/games/minisoccer/'>Play MiniSoccer</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/MiniSoccer.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 7,
                //    Name = "Calabash Bros",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='calabash-bros' data-theme='0' data-width='700' data-height='570' data-language='en'><a href='http://www.miniclip.com/games/calabash-bros/'>Play Calabash Bros</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/CalabashBros.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 8,
                //    Name = "Basketball Jam",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='basketball-jam-shots' data-theme='0' data-width='750' data-height='580' data-language='en'><a href='http://www.miniclip.com/games/basketball-jam-shots/'>Play Basketball Jam Shots</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/basketballjamshots.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 9,
                //    Name = "Total Wreckage",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='total-wreckage' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/total-wreckage/'>Play Total Wreckage</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/totalwreckage.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 10,
                //    Name = "Western Front",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='western-front-1914' data-theme='0' data-width='680' data-height='520' data-language='en'><a href='http://www.miniclip.com/games/western-front-1914/'>Play Western Front 1914</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/westernfront1914.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 11,
                //    Name = "Turbo Racing 3",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='turbo-racing-3' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/turbo-racing-3/'>Play Turbo Racing 3</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/turboracing3.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 12,
                //    Name = "Saloon Brawl 2",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='saloon-brawl-2' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/saloon-brawl-2/'>Play Saloon Brawl 2</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/saloonbrawl2.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 13,
                //    Name = "After Sunset 2",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='after-sunset-2' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/after-sunset-2/'>Play After Sunset 2</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/aftersunset2christmas.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 14,
                //    Name = "Zombie Trapper 2",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='zombie-trapper-2' data-theme='0' data-width='650' data-height='450' data-language='en'><a href='http://www.miniclip.com/games/zombie-trapper-2/'>Play Zombie Trapper 2</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/zombietrapper2.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 15,
                //    Name = "Assault Course 2",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='assault-course-2' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/assault-course-2/'>Play Assault Course 2</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/assaultcourse2.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 16,
                //    Name = "Free Running 2",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='free-running-2' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/free-running-2/'>Play Free Running 2</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/freerunning2christmas.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 17,
                //    Name = "Horde Siege",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='horde-siege' data-theme='0' data-width='640' data-height='480' data-language='en'><a href='http://www.miniclip.com/games/horde-siege/'>Play Horde Siege</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/hordesiege.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 18,
                //    Name = "Slime Laboratory 2",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='slime-laboratory-2' data-theme='0' data-width='640' data-height='480' data-language='en'><a href='http://www.miniclip.com/games/slime-laboratory-2/'>Play Slime Laboratory 2</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/slimelab2.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 19,
                //    Name = "Bow Master Japan",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='bow-master-japan' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/bow-master-japan/'>Play Bow Master Japan</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/bowmasterj2.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 20,
                //    Name = "Monster Stunts",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='monster-stunts' data-theme='0' data-width='800' data-height='600' data-language='en'><a href='http://www.miniclip.com/games/monster-stunts/'>Play Monster Stunts</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/monsterstuntsmedicon.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 21,
                //    Name = "Jack Lantern",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='jack-lantern' data-theme='0' data-width='608' data-height='400' data-language='en'><a href='http://www.miniclip.com/games/jack-lantern/'>Play Jack Lantern</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/jacklanternmedicon.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 22,
                //    Name = "Forest Siege",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='forest-siege' data-theme='0' data-width='700' data-height='440' data-language='en'><a href='http://www.miniclip.com/games/forest-siege/'>Play Forest Siege</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/forestsiegemedicon.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 23,
                //    Name = "Assault Course 2",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='assault-course-2' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/assault-course-2/'>Play Assault Course 2</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/assaultcourse2.jpg"
                //},
                //new EmbeddedGame
                //{
                //    Id = 24,
                //    Name = "Saloon Brawl 2",
                //    GameContent = "<div class='miniclip-game-embed' data-game-name='saloon-brawl-2' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/saloon-brawl-2/'>Play Saloon Brawl 2</a></div>",
                //    ImagePath = "/Content/EmbeddedGames/Images/saloonbrawl2.jpg"
                //}
                );
        }
    }
}
