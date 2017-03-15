using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPart1
{
    abstract public class Football
    {
        public string TeamName { get; set; }

        //Default construstor used for inheritence
        //Also needed for other classes
        public Football()
        {
        }

        public Football(string teamName)
        {
            this.TeamName = teamName;
        }
    }

    public class Player : Football
    {
        public string PlayerSurname { get; set; }
        public string PlayerNationality { get; set; }
        public string ShirtNumber { get; set; }

        public Player()
        {
        }

        public Player(string playerSurname, string playerNationality, string shirtNumber)
        {
            this.PlayerSurname = playerSurname;
            this.PlayerNationality = playerNationality;
            this.ShirtNumber = shirtNumber;
        }

        public override string ToString()
        {
            return "Player: " + PlayerSurname + "\nNationality: " + PlayerNationality + "\nTeam: " + TeamName;
        }
    }

    //All of the data that is used for the team and the manager class
    public class Team : Football
    {
        public int GoalDifference { get; set; }
        public int Points { get; set; }

        public Team()
        {
        }

        public Team(int goalDifference, int points)
        {
            this.GoalDifference = goalDifference;
            this.Points = points;;
        }

        public override string ToString()
        {
            return "Team Name: " + TeamName + "\nGoal Difference: " + GoalDifference + "\nPoints: " + Points;
        }
    }

    class Result : Team
    {
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }

        public Result()
        {
        }

        public Result(int wins, int draws, int losses)
        {
            this.Wins = wins;
            this.Draws = draws;
            this.Losses = losses;
        }
    }

    class Manager : Team
    {
        public string ManagerName { get; set; }
        public string ManagerNationality { get; set; }

        public Manager()
        {
        }

        public Manager(string managerName, string managerNationality)
        {
            this.ManagerName = managerName;
            this.ManagerNationality = managerNationality;
        }
    }
}
