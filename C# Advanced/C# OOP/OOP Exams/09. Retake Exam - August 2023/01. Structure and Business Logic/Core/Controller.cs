using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Utilities.Messages;

namespace Handball.Core
{
    public class Controller : IController
    {
        private PlayerRepository players = new();
        private TeamRepository teams = new();
        private List<string> playerTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.Namespace == "Handball.Models.Players")
            .Select(t => t.Name)
            .ToList();


        public string NewTeam(string name)
        {
            if (teams.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, teams.GetType().Name);
            }

            teams.AddModel(new Team(name));
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, teams.GetType().Name);
        }

        public string NewPlayer(string typeName, string name)
        {
            if (!playerTypes.Contains(typeName))
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            IPlayer player = players.GetModel(name);
            if (player != null)
            {
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, 
                    players.GetType().Name,
                    player.GetType().Name);
            }

            Type type = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == typeName);
            IPlayer model = Activator.CreateInstance(type, new object[]{name}) as IPlayer;
            players.AddModel(model);

            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewContract(string playerName, string teamName)
        {
            IPlayer player = players.GetModel(playerName);
            if (player == null)
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, players.GetType().Name);
            }

            ITeam team = teams.GetModel(teamName);
            if (team == null)
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, teams.GetType().Name);
            }

            string playerTeam = player.Team;
            if (playerTeam != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, playerTeam);
            }

            player.JoinTeam(teamName);
            team.SignContract(player);

            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teams.GetModel(firstTeamName);
            ITeam secondTeam = teams.GetModel(secondTeamName);

            if (firstTeam.OverallRating > secondTeam.OverallRating)
            {
                firstTeam.Win();
                secondTeam.Lose();
                return string.Format(OutputMessages.GameHasWinner, firstTeamName, secondTeamName);
            }

            else if (firstTeam.OverallRating < secondTeam.OverallRating)
            {
                firstTeam.Lose();
                secondTeam.Win();
                return string.Format(OutputMessages.GameHasWinner, secondTeamName, firstTeamName);
            }

            else //DRAW 
            {
                firstTeam.Draw();
                secondTeam.Draw();
                return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);
            }
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();
            ITeam team = teams.GetModel(teamName);
            List<IPlayer> orderedPlayers = team.Players
                .OrderByDescending(p => p.Rating)
                .ThenBy(p => p.Name)
                .ToList();

            sb.AppendLine($"***{team.Name}***");
            foreach (var player in orderedPlayers)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }

        public string LeagueStandings()
        {
            StringBuilder sb = new StringBuilder();
            List<ITeam> orderedTeams = teams.Models
                .OrderByDescending(t => t.PointsEarned)
                .ThenByDescending(t => t.OverallRating)
                .ThenBy(t => t.Name).ToList();

            sb.AppendLine("***League Standings***");
            foreach (var team in orderedTeams)
                sb.AppendLine(team.ToString());

            return sb.ToString().Trim();
        }
    }
}
