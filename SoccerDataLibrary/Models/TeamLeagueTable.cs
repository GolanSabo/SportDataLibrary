using System;

namespace SoccerDataLibrary
{
    /// <summary>
    /// Class that give information about team comparing to other 
    /// teams in the same league
    /// </summary>
    class TeamLeagueTable
    {
        private int position;
        private int playedGames;
        private int points;
        private int goals;
        private int goalsAgainst;
        private int goalDifference;
        /// <summary>
        /// C'tor
        /// </summary>
        /// <param name="position"></param>
        /// <param name="playedGames"></param>
        /// <param name="points"></param>
        /// <param name="goals"></param>
        /// <param name="goalsAgainst"></param>
        /// <param name="goalDifference"></param>
        public TeamLeagueTable(int position, int playedGames, int points, int goals, int goalsAgainst, int goalDifference)
        {
            Points = points;
            Position = position;
            PlayedGames = playedGames;
            GoalDifference = goalDifference;
            GoalsAgainst = goalsAgainst;
            Goals = goals;
        }
        /// <summary>Property showing the position of a team in league table</summary>
        public int Position { private set { position = value; } get { return position; } }
        /// <summary>Property showing the number of games played</summary>
        public int PlayedGames { private set { playedGames = value; } get { return playedGames; } }
        /// <summary>Property showing the number of points of a team</summary>
        public int Points { private set { points = value; } get { return points; } }
        /// <summary>Property showing the number of goals scored</summary>
        public int Goals { private set { goals = value; } get { return goals; } }
        /// <summary>Property showing the number of goals a team recieved</summary>
        public int GoalsAgainst { private set { goalsAgainst = value; } get { return goalsAgainst; } }
        /// <summary>Property showing goals scored - goals recieved </summary>
        public int GoalDifference { private set { goalDifference = value; } get { return goalDifference; } }

        /// <summary>Returns the details of a player ready for printing.</summary>
        public override String ToString()
        {
            return "Position In League: " + Position + "\nPlayed Games: " + PlayedGames + "\nPoints: " + Points +"\nGoals: " + Goals + "\nGoals Against: " + GoalsAgainst + "\nGoal Difference: " + GoalDifference+"\n";
        }

    }
}
