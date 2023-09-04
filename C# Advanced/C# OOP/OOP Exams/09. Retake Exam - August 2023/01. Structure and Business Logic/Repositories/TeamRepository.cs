using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Models.Players;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> teams = new();

        public IReadOnlyCollection<ITeam> Models => teams;

        public void AddModel(ITeam model) => teams.Add(model);

        public bool RemoveModel(string name)
            => teams.Remove(teams.Find(p => p.Name == name));

        public bool ExistsModel(string name)
            => teams.Any(p => p.Name == name);

        public ITeam GetModel(string name)
            => teams.FirstOrDefault(p => p.Name == name);
    }
}
