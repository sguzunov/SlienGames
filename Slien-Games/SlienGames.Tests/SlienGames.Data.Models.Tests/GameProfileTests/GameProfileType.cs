﻿using NUnit.Framework;
using SlienGames.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Tests.SlienGames.Data.Models.Tests.GameProfileTests
{
    [TestFixture]
    public class GameProfileType
    {
        [Test]
        public void ShouldBe_IDbModel()
        {
            var gameProfile = new GameProfile();

            //var result = gameProfile.GetType().GetInterfaces().Any(x => x == typeof(IDbModel));

            //Assert.True(result);
        }
    }
}
