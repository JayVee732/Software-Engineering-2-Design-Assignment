using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPart1
{
    abstract class Football
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

    class Player : Football
    {
        public string PlayerSurname { get; set; }
        public string PlayerNationality { get; set; }
        public int ShirtNumber { get; set; }

        public Player()
        {
        }

        public Player(string playerSurname, string playerNationality, int shirtNumber)
        {
            this.PlayerSurname = playerSurname;
            this.PlayerNationality = playerNationality;
            this.ShirtNumber = shirtNumber;
        }
    }

    //All of the data that is used for the team and the manager class
    class Teams : Football
    {
        public string ClubLocation { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }
        public int TablePosition { get; set; }

        public Teams()
        {
        }

        public Teams(string clubLocation, int goalDifference, int points, int tablePosition)
        {
            this.ClubLocation = clubLocation;
            this.GoalDifference = goalDifference;
            this.Points = points;
            this.TablePosition = tablePosition;
        }
    }

    class Results : Teams
    {
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }

        public Results()
        {
        }

        public Results(int wins, int draws, int losses)
        {
            this.Wins = wins;
            this.Draws = draws;
            this.Losses = losses;
        }
    }

    class Managers : Teams
    {
        public string ManagerName { get; set; }
        public string ManagerNationality { get; set; }

        public Managers()
        {
        }

        public Managers(string managerName, string managerNationality)
        {
            this.ManagerName = managerName;
            this.ManagerNationality = managerNationality;
        }
    }
}
