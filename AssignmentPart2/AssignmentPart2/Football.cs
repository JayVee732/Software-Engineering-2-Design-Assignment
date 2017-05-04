using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentPart2
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
            return "Surname: " + PlayerSurname + "\tNationality: " + PlayerNationality + "\nShirt Number: " + ShirtNumber + "\tTeam: " + TeamName;
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
            this.Points = points;
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

    public class Manager : Team
    {
        public string ManagerName { get; set; }
        public string ManagerNationality { get; set; }

        public Manager()
        {
        }

        public Manager(string teamName, string managerName, string managerNationality)
        {
            this.TeamName = teamName;
            this.ManagerName = managerName;
            this.ManagerNationality = managerNationality;
        }

        public override string ToString()
        {
            return "Manager Name: " + ManagerName + "\nTeam Name: " + TeamName + "\nManager Nationality: " + ManagerNationality;
        }
    }

    //public abstract class Person
    //{
    //    public string FirstName { get; set; }
    //    public string Surname { get; set; }
    //    public string Nationality { get; set; }
    //    public int Age { get; set; }

    //    public Person()
    //    {

    //    }

    //    public Person(string firstName, string surname, string nationality, int age)
    //    {
    //        this.FirstName = firstName;
    //        this.Surname = surname;
    //        this.Nationality = nationality;
    //        this.Age = age;
    //    }
    //}

    //class Player : Person
    //{
    //    public string ShirtNumber { get; set; }

    //    public Player()
    //    {

    //    }

    //    public Player(string shirtNumber)
    //    {
    //        this.ShirtNumber = shirtNumber;
    //    }
    //}

    //class Manager : Person
    //{
    //    public string Team { get; set; }

    //    public Manager()
    //    {

    //    }

    //    public Manager(string team)
    //    {
    //        this.Team = team;
    //    }
    //}
}
