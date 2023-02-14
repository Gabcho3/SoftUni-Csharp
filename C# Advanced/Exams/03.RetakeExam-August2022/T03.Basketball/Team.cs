using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            Players = new List<Player>();
            Name = name;
            OpenPositions = openPositions;
            Group = group;
        }

        public List<Player> Players { get; set; }

        public string Name { get; set; }

        public int OpenPositions { get; set; }

        public char Group { get; set; }

        public int Count => Players.Count;

        public string AddPlayer(Player player)
        {
            string playerName = player.Name;
            string playerPosition = player.Position;
            double playerRating = player.Rating;

            if (playerName == null || playerPosition == null || playerName == string.Empty || playerPosition == string.Empty)
            {
                return "Invalid player's information.";
            }

            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (playerRating < 80)
            {
                return "Invalid player's rating.";
            }

            Players.Add(player);
            return $"Successfully added {playerName} to the team. Remaining open positions: {--OpenPositions}.";
        }

        public bool RemovePlayer (string name)
        {
            Player player = Players.Find(x => x.Name == name);

            if (player != null)
            {
                Players.Remove(player);
                OpenPositions++;
                return true;
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            var playersWithPosition = Players.FindAll(x => x.Position == position);
            Players.RemoveAll(x => x.Position == position);
            OpenPositions += playersWithPosition.Count;
            return playersWithPosition.Count;
        }

        public Player RetirePlayer(string name)
        {
            Player playerToRetire = Players.Find(x => x.Name == name);

            if (playerToRetire != null)
            {
                playerToRetire.Retired = true;
                return playerToRetire;
            }

            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            return Players.Where(x => x.Games >= games).ToList();
        }

        public string Report()
        {
            List<Player> activePlayers = Players.Where(x => x.Retired == false).ToList();
            string output = $"Active players competing for Team {Name} from Group {Group}:";

            foreach(var player in activePlayers)
            {
                output += Environment.NewLine + player.ToString();
            }

            return output;
        }
    }
}
