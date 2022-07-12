using System;
using System.Collections.Generic;
using System.Text;

namespace P05.FootballTeamGenerator
{
    public static class ErrorMessages
    {
        public const string NullOrWhiteSpaceName = "A name should not be empty.";
        public const string StatInvalidValue = "{0} should be between 0 and 100";
        public const string PlayerNotInTeam = "Player {0} is not in {1} team.";
    }
}
