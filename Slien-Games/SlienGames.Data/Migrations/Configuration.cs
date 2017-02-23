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
                    Description = "Play this super cool sports game, Flip Diving! Just jump and start spinning to make the perfect dive while collecting coins. Don't perform belly- or back flops or you will obviously lose. Go get your high score now!",
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
                    Description = "Play fast-paced, authentic 1v1 multiplayer basketball! Show your skills, moves and fakes to juke out your opponent and shoot for the basket! On defense, stay in the face of the attacker, steal the ball, and time your leaps to block their shots! All in REAL-TIME!",
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
                    Description = "Customize your cue and table! In every competitive 1-vs-1 match you play, there’ll be Pool Coins at stake – win the match and the Coins are yours. You can use these to enter higher ranked matches with bigger stakes, or to buy new items in the Pool Shop.",
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
                     Description = "An army of ghostly wisps are trying to ruin Halloween! Can you bust these scary spirits? Take them down with your enchanted bow in this spook-tacular action game.",
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
                 },
                 new GameDetails
                 {
                     Id = 5,
                     Name = "Stealth Sniper",
                     CreatedOn = DateTime.Now,
                     Description = "Choose your sniper rifle, go into the briefing room and get ready to travel the world while killing special targets. In each mission you have to check the territory first. Take out your victims and shoot them without setting off the alert.",
                     ExternalResource = new ExternalGameResource
                     {
                         Id = 5,
                         GameContent = "<div class='miniclip-game-embed' data-game-name='bow-master-halloween' data-theme='0'  data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/bow-master-halloween/'>Play Bow Master Halloween</a></div>",

                     },
                     CoverImage = new CoverImage
                     {
                         Id = 5,
                         FileExtension = "jpg",
                         FileName = "stealthsniper",
                         FileSystemUrlPath = "/Content/EmbeddedGames/Images/stealthsniper.jpg",
                         GameId = 5
                     }
                 },
                 new GameDetails
                 {
                     Id = 6,
                     Name = "MiniSoccer",
                     CreatedOn = DateTime.Now,
                     Description = "Shoot your way to victory. Play in Friendlies or compete in a tournament and go for Gold.",
                     ExternalResource = new ExternalGameResource
                     {
                         Id = 6,
                         GameContent = "<div class='miniclip-game-embed' data-game-name='minisoccer' data-theme='0' data-width='800' data-height='700' data-language='en'><a href='http://www.miniclip.com/games/minisoccer/'>Play MiniSoccer</a></div>",

                     },
                     CoverImage = new CoverImage
                     {
                         Id = 6,
                         FileExtension = "jpg",
                         FileName = "MiniSoccer",
                         FileSystemUrlPath = "/Content/EmbeddedGames/Images/MiniSoccer.jpg",
                         GameId = 6
                     }
                 },
                new GameDetails
                {
                    Id = 7,
                    Name = "Calabash Bros",
                    CreatedOn = DateTime.Now,
                    Description = "A horde of strange and vicious creatures is pouring into the lands of the Calabash Bros. Protect the territory from enemy attack by building a variety of towers.",
                    ExternalResource = new ExternalGameResource
                    {
                        Id = 7,
                        GameContent = "<div class='miniclip-game-embed' data-game-name='calabash-bros' data-theme='0' data-width='700' data-height='570' data-language='en'><a href='http://www.miniclip.com/games/calabash-bros/'>Play Calabash Bros</a></div>",

                    },
                    CoverImage = new CoverImage
                    {
                        Id = 7,
                        FileExtension = "jpg",
                        FileName = "CalabashBros",
                        FileSystemUrlPath = "/Content/EmbeddedGames/Images/CalabashBros.jpg",
                        GameId = 7
                    }
                },
                 new GameDetails
                 {
                     Id = 8,
                     Name = "Basketball Jam",
                     CreatedOn = DateTime.Now,
                     Description = "It's time for a hoop-shooting showdown! A crew of the best basketball players around are here to show off their skills. Set the trajectory of the ball and then shoot - but keep an eye on the other players! Some of them don't always like to play fair.",
                     ExternalResource = new ExternalGameResource
                     {
                         Id = 8,
                         GameContent = "<div class='miniclip-game-embed' data-game-name='basketball-jam-shots' data-theme='0' data-width='750' data-height='580' data-language='en'><a href='http://www.miniclip.com/games/basketball-jam-shots/'>Play Basketball Jam Shots</a></div>",

                     },
                     CoverImage = new CoverImage
                     {
                         Id = 8,
                         FileExtension = "jpg",
                         FileName = "basketballjamshots",
                         FileSystemUrlPath = "/Content/EmbeddedGames/Images/basketballjamshots.jpg",
                         GameId = 8
                     }
                 },
                new GameDetails
                {
                    Id = 9,
                    Name = "Total Wreckage",
                    CreatedOn = DateTime.Now,
                    Description = "Crash and smash your way through a series of demolition derbies in Total Wreckage, a hard-hitting game of vehicular destruction! Eliminate the minimum number of cars shown to win each contest and move on to the next. Hit the turbo boost to ram other cars at maximum speed or evade other drivers.",
                    ExternalResource = new ExternalGameResource
                    {
                        Id = 9,
                        GameContent = "<div class='miniclip-game-embed' data-game-name='total-wreckage' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/total-wreckage/'>Play Total Wreckage</a></div>",
                    },
                    CoverImage = new CoverImage
                    {
                        Id = 9,
                        FileExtension = "jpg",
                        FileName = "totalwreckage",
                        FileSystemUrlPath = "/Content/EmbeddedGames/Images/totalwreckage.jpg",
                        GameId = 9
                    }
                },
                new GameDetails
                {
                    Id = 10,
                    Name = "Turbo Racing 3",
                    CreatedOn = DateTime.Now,
                    Description = "Turbo Racing 3 speeds this top racing series to the streets of Shanghai. Put the pedal to the metal and accelerate into oncoming traffic while blowing through speed traps. Use the turbo boost to leave opponents eating your dust and avoid elimination at the checkpoints.",
                    ExternalResource = new ExternalGameResource
                    {
                        Id = 10,
                        GameContent = "<div class='miniclip-game-embed' data-game-name='turbo-racing-3' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/turbo-racing-3/'>Play Turbo Racing 3</a></div>",
                    },
                    CoverImage = new CoverImage
                    {
                        Id = 10,
                        FileExtension = "jpg",
                        FileName = "turboracing3",
                        FileSystemUrlPath = "/Content/EmbeddedGames/Images/turboracing3.jpg",
                        GameId = 10
                    }
                },
                new GameDetails
                {
                    Id = 11,
                    Name = "Saloon Brawl 2",
                    CreatedOn = DateTime.Now,
                    Description = "The Sheriff is back in town! The citizens of the Wild West are tearing everything apart again with their constant brawling. Join in the brawl and knock out the other fighters.",
                    ExternalResource = new ExternalGameResource
                    {
                        Id = 11,
                        GameContent = "<div class='miniclip-game-embed' data-game-name='saloon-brawl-2' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/saloon-brawl-2/'>Play Saloon Brawl 2</a></div>"
                    },
                    CoverImage = new CoverImage
                    {
                        Id = 11,
                        FileExtension = "jpg",
                        FileName = "saloonbrawl2",
                        FileSystemUrlPath = "/Content/EmbeddedGames/Images/saloonbrawl2.jpg",
                        GameId = 11
                    }
                },
                new GameDetails
                {
                    Id = 12,
                    Name = "After Sunset 2",
                    CreatedOn = DateTime.Now,
                    Description = "The zombies are coming in After Sunset 2! And all you have to protect you is your meat cleaver and... a whole host of special weapons. Look out for emergency airdrops and watch your back – these zombies are sneaky! Aim for the brain and put them back in the ground.",
                    ExternalResource = new ExternalGameResource
                    {
                        Id = 12,
                        GameContent = "<div class='miniclip-game-embed' data-game-name='after-sunset-2' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/after-sunset-2/'>Play After Sunset 2</a></div>",
                    },
                    CoverImage = new CoverImage
                    {
                        Id = 12,
                        FileExtension = "jpg",
                        FileName = "aftersunset2christmas",
                        FileSystemUrlPath = "/Content/EmbeddedGames/Images/aftersunset2christmas.jpg",
                        GameId = 12
                    }
                },
                new GameDetails
                {
                    Id = 13,
                    Name = "Zombie Trapper 2",
                    CreatedOn = DateTime.Now,
                    Description = "Zombies are unbelievably rude. They are after your air-purifier so stop them before they get it! Trap, shoot, beat and blow up zombies in this Zombie survival game - Zombie Trapper 2. Use cunning trap placement and increasingly powerful guns to stop the walking brainless savages.",
                    ExternalResource = new ExternalGameResource
                    {
                        Id = 13,
                        GameContent = "<div class='miniclip-game-embed' data-game-name='zombie-trapper-2' data-theme='0' data-width='650' data-height='450' data-language='en'><a href='http://www.miniclip.com/games/zombie-trapper-2/'>Play Zombie Trapper 2</a></div>",
                    },
                    CoverImage = new CoverImage
                    {
                        Id = 13,
                        FileExtension = "jpg",
                        FileName = "zombietrapper2",
                        FileSystemUrlPath = "/Content/EmbeddedGames/Images/zombietrapper2.jpg",
                        GameId = 13
                    }
                },
                new GameDetails
                {
                    Id = 14,
                    Name = "Assault Course 2",
                    CreatedOn = DateTime.Now,
                    Description = "Zombies are unbelievably rude. They are after your air-purifier so stop them before they get it! Trap, shoot, beat and blow up zombies in this Zombie survival game - Zombie Trapper 2. Use cunning trap placement and increasingly powerful guns to stop the walking brainless savages.",
                    ExternalResource = new ExternalGameResource
                    {
                        Id = 14,
                        GameContent = "<div class='miniclip-game-embed' data-game-name='assault-course-2' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/assault-course-2/'>Play Assault Course 2</a></div>",
                    },
                    CoverImage = new CoverImage
                    {
                        Id = 14,
                        FileExtension = "jpg",
                        FileName = "assaultcourse2",
                        FileSystemUrlPath = "/Content/EmbeddedGames/Images/assaultcourse2.jpg",
                        GameId = 14
                    }
                },
                new GameDetails
                {
                    Id = 15,
                    Name = "Free Running 2",
                    CreatedOn = DateTime.Now,
                    Description = "Free Running 2 is the sequel to our smash-hit parkour game, featuring stunning 3D graphics, new moves, more game modes and challenges. Perform the same feats of athleticism and courage as parkour superstars like Sebastien Foucan and David Belle without leaving your computer.",
                    ExternalResource = new ExternalGameResource
                    {
                        Id = 15,
                        GameContent = "<div class='miniclip-game-embed' data-game-name='free-running-2' data-theme='0' data-width='680' data-height='510' data-language='en'><a href='http://www.miniclip.com/games/free-running-2/'>Play Free Running 2</a></div>",
                    },
                    CoverImage = new CoverImage
                    {
                        Id = 15,
                        FileExtension = "jpg",
                        FileName = "freerunning2christmas",
                        FileSystemUrlPath = "/Content/EmbeddedGames/Images/freerunning2christmas.jpg",
                        GameId = 15
                    }
                },
                new GameDetails
                {
                    Id = 16,
                    Name = "Horde Siege",
                    CreatedOn = DateTime.Now,
                    Description = "The castle is under siege and only you can hold off the enemy for next 25 days until reinforcements arrive. Use your bow to shoot the oncoming horde of enemies to protect the castle entrance. Remember to upgrade your weapon and use the garrison for additional fire power.",
                    ExternalResource = new ExternalGameResource
                    {
                        Id = 16,
                        GameContent = "<div class='miniclip-game-embed' data-game-name='horde-siege' data-theme='0' data-width='640' data-height='480' data-language='en'><a href='http://www.miniclip.com/games/horde-siege/'>Play Horde Siege</a></div>",
                    },
                    CoverImage = new CoverImage
                    {
                        Id = 16,
                        FileExtension = "jpg",
                        FileName = "hordesiege",
                        FileSystemUrlPath = "/Content/EmbeddedGames/Images/hordesiege.jpg",
                        GameId = 16
                    }
                },
                new GameDetails
                {
                    Id = 17,
                    Name = "TicTacToe",
                    CreatedOn = DateTime.Now,
                    Description = "A game in which two players alternately put Xs and Os in compartments of a figure formed by two vertical lines crossing two horizontal lines and each tries to get a row of three Xs or three Os before the opponent does",
                    CoverImage = new CoverImage
                    {
                        Id = 17,
                        FileExtension = "png",
                        FileName = "tic-tac-toe",
                        FileSystemUrlPath = "/Content/OurBrand/Images/tic-tac-toe.png",
                        GameId = 17
                    }
                }
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
