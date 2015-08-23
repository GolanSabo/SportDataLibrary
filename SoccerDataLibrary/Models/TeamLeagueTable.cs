using System;

namespace SoccerDataLibrary
{
    class TeamLeagueTable
    {
        private int position;
        private int playedGames;
        private int points;
        private int goals;
        private int goalsAgainst;
        private int goalDifference;

        public TeamLeagueTable(int position, int playedGames, int points, int goals, int goalsAgainst, int goalDifference)
        {
            Points = points;
            Position = position;
            PlayedGames = playedGames;
            GoalDifference = goalDifference;
            GoalsAgainst = goalsAgainst;
            Goals = goals;
        }

        public int Position { private set { position = value; } get { return position; } }
        public int PlayedGames { private set { playedGames = value; } get { return playedGames; } }
        public int Points { private set { points = value; } get { return points; } }
        public int Goals { private set { goals = value; } get { return goals; } }
        public int GoalsAgainst { private set { goalsAgainst = value; } get { return goalsAgainst; } }
        public int GoalDifference { private set { goalDifference = value; } get { return goalDifference; } }


        public override String ToString()
        {
            return "Position In League: " + Position + "\nPlayed Games: " + PlayedGames + "\nPoints: " + Points +"\nGoals: " + Goals + "\nGoals Against: " + GoalsAgainst + "\nGoal Difference: " + GoalDifference+"\n";
        }

    }
}
