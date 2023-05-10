using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballPlayer player;
        private FootballTeam team;

        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer("Gabcho", 3, "Midfielder");
            team = new FootballTeam("Team 06", 20);
        }

        [Test]
        public void Test_ConstructorWorksProperly()
        {
            Assert.AreEqual("Team 06", team.Name);
            Assert.AreEqual(20, team.Capacity);
            var testListPlayers = new List<FootballPlayer>();
            Assert.AreEqual(testListPlayers, team.Players);
        }

        [Test]
        public void Test_NameInNullOrEmptyThrows()
        {
            TestDelegate testDelegate = () => { team.Name = null; team.Name = string.Empty; };
            Assert.Throws<ArgumentException>(testDelegate);
        }

        [Test]
        public void Test_CapacityUnder15Throws()
        {
            TestDelegate testDelegate = () => team.Capacity = 14; ;
            Assert.Throws<ArgumentException>(testDelegate);
        }

        [Test]
        public void Test_TryingToAddMorePlayersThanCapacityReturns()
        {
            int playerNumber = 1;
            char name = 'a';
            while(team.Players.Count < 20)
            {
                team.AddNewPlayer(new FootballPlayer(name.ToString(), playerNumber, "Midfielder"));
                name++;
            }
            string returns = team.AddNewPlayer(player);
            Assert.AreEqual("No more positions available!", returns);
        }

        [Test]
        public void Test_AddNewPlayerWorksProperly()
        {
            string returns = team.AddNewPlayer(player);
            Assert.AreEqual($"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}", returns);
            Assert.AreEqual(1, team.Players.Count);
        }

        [Test]
        public void Test_PichPlayerWorksProperly()
        {
            team.AddNewPlayer(player);
            FootballPlayer pickedPlayer = team.PickPlayer("Gabcho");
            Assert.AreEqual(player, pickedPlayer);
        }

        [Test]
        public void Test_PlayerScoredWorksProperly()
        {
            team.AddNewPlayer(player);
            string returns = team.PlayerScore(3);
            Assert.AreEqual($"{player.Name} scored and now has {player.ScoredGoals} for this season!", returns);
        }
    }
}