using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private readonly List<Player> players;
        public Team( string name)
        {
            this.players = new List<Player>();
            this.Name = name;
        }
        public string Name 
        { 
            get
            {
                return this.Name;
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.NullOrWhiteSpaceName);
                }
                this.name = value;
            }
        }
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player playerToDelete = this.players
                .FirstOrDefault(p => p.Name == playerName);

            if (playerToDelete == null)
            {
                throw new InvalidOperationException(
                    String.Format(ErrorMessages.PlayerNotInTeam, playerName, this.Name));
            }

            this.players.Remove(playerToDelete);
        }
    }
}
