using System;
using System.Collections.Generic;
using System.Text;

namespace P05.FootballTeamGenerator
{
    public class Team
    {
        public Team(int numberOfPlayers, string name, double rating)
        {
            this.NumberOfPlayers = numberOfPlayers;
            this.Name = name;
            this.Rating = rating;
        }

        public int NumberOfPlayers { get; private set; }
        public string Name { get; private set; }
        public double Rating { get; set; }
    }
}
