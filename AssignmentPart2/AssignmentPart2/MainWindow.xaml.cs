using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AssignmentPart2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Team> teamList = new List<Team>();
        public List<Manager> managerList = new List<Manager>();
        List<string> saveDataList = new List<string>();
        public List<Player> playerList = new List<Player>();
        public List<Player> FilteredplayerList = new List<Player>();


        string team = null;
        string manager = null;

        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Default teams, will change later to reflect Premier League
            //Team t1 = new Team() { TeamName = "Liverpool", GoalDifference = 9, Points = 6 };
            //Team t2 = new Team() { TeamName = "Manchester United", GoalDifference = 4, Points = 2435 };
            //Team t3 = new Team() { TeamName = "Arsenal", GoalDifference = 89, Points = 34 };
            //Team t4 = new Team() { TeamName = "Chelsea", GoalDifference = 420, Points = 987234 };
            //Team t5 = new Team() { TeamName = "Norwich", GoalDifference = 420, Points = 987234 };

            /* Player p1 = new Player() { TeamName = "Liverpool", PlayerSurname = "Keane", PlayerNationality = "Irish", ShirtNumber = "5" };
            Player p2 = new Player() { TeamName = "Manchester United", PlayerSurname = "Rooney", PlayerNationality = "English", ShirtNumber = "7" };
            Player p3 = new Player() { TeamName = "Arsenal", PlayerSurname = "Sanchez", PlayerNationality = "Somethin", ShirtNumber = "9" };
            Player p4 = new Player() { TeamName = "Chelsea", PlayerSurname = "Drogba", PlayerNationality = "Iduno", ShirtNumber = "6" };
            Player p5 = new Player() { TeamName = "Norwich", PlayerSurname = "Bolder", PlayerNationality = "RockBased", ShirtNumber = "7" };

            playerList.Add(p1);
            playerList.Add(p2);
            playerList.Add(p3);
            playerList.Add(p4);
            playerList.Add(p5); */

            //teamList.Add(t1);
            //teamList.Add(t2);
            //teamList.Add(t3);
            //teamList.Add(t4);
            //teamList.Add(t5);

            //lbxDisplay.ItemsSource = teamList;
            //listBox_Players.ItemsSource = playerList;
        }

        private void btnAddTeam_Click(object sender, RoutedEventArgs e)
        {
            //Clears the listbox of all previous values
            lbxDisplay.ItemsSource = "";

            teamList.Add(new Team() { TeamName = tbxTeamName.Text, GoalDifference = int.Parse(tbxGoalDifference.Text), Points = int.Parse(tbxClubPoints.Text) });

            //Adds listbox with new values
            lbxDisplay.ItemsSource = teamList;
        }

        private void btnAddManager_Click(object sender, RoutedEventArgs e)
        {
            lbxManagerDisplay.ItemsSource = "";
            team = "";
            manager = "";

            foreach (var teamName in teamList)
            {
                team = teamName.TeamName;
                manager = tbxManagerTeam.Text;

                if (team == manager)
                {
                    managerList.Add(new Manager() { ManagerName = tbxMangerName.Text, ManagerNationality = tbxManagerNationality.Text, TeamName = tbxManagerTeam.Text });
                }

            }

            tbxMangerName.Text = String.Empty;
            tbxManagerNationality.Text = String.Empty;
            tbxManagerTeam.Text = String.Empty;

            lbxManagerDisplay.ItemsSource = managerList;
        }

        private void btnRemoveManager_Click(object sender, RoutedEventArgs e)
        {
            Manager selectedManager = lbxManagerDisplay.SelectedItem as Manager;

            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to remove this manager?", "Delete Manager?", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (selectedManager != null)
                {
                    managerList.Remove(selectedManager);
                    lbxManagerDisplay.ItemsSource = "";
                    lbxManagerDisplay.ItemsSource = managerList;
                }
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lbxDisplay.ItemsSource = "";
                lbxManagerDisplay.ItemsSource = "";
                listBox_Players.ItemsSource = "";
                managerList.Clear();
                teamList.Clear();
                playerList.Clear();

                //Reading from the file
                using (StreamReader sr = new StreamReader("footballData.txt"))
                {
                    string data = sr.ReadLine();

                    while (data != null)
                    {
                        string[] newData = data.Split(',');
                        string checkData = newData[0];

                        //Checks the data type and makes a new object
                        switch (checkData)
                        {
                            case "Manager":
                                managerList.Add(new Manager() { ManagerName = newData[1], ManagerNationality = newData[2], TeamName = newData[3] });

                                newData = null;
                                data = sr.ReadLine();
                                break;
                            case "Team":
                                teamList.Add(new Team() { TeamName = newData[1], GoalDifference = int.Parse(newData[2]), Points = int.Parse(newData[3]) });

                                newData = null;
                                data = sr.ReadLine();
                                break;
                            case "Player":
                                playerList.Add(new Player() { TeamName = newData[1], PlayerSurname = (newData[2]), PlayerNationality = (newData[3]), ShirtNumber = (newData[4]) });
                                newData = null;
                                data = sr.ReadLine();
                                break;

                        }
                    }
                    sr.Close();
                }
            }

            catch (FileNotFoundException fnfe)
            {
                MessageBox.Show(fnfe.Message);
            }

            //sorts the teams by points
            teamList = teamList.OrderBy(o => o.Points).ToList();

            lbxDisplay.ItemsSource = teamList;
            lbxManagerDisplay.ItemsSource = managerList;
            listBox_Players.ItemsSource = playerList;
        }

        private void btn_AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            // Adding a player to the list

            listBox_Players.ItemsSource = "";

            playerList.Add(new Player() { PlayerSurname = txtbox_PlayerTeam.Text, PlayerNationality = Player_Nationality.Text, ShirtNumber = Player_Number.Text, TeamName = txtbox_PlayerTeam.Text });

            Player_Surname.Text = String.Empty;
            Player_Nationality.Text = String.Empty;
            Player_Number.Text = String.Empty;
            txtbox_PlayerTeam.Text = String.Empty;

            listBox_Players.ItemsSource = playerList;
        }

        private void btn_RemovePlayer_Click(object sender, RoutedEventArgs e)
        {
            // Removing a players from the team list with verification

            {
                Player selectedPlayer = listBox_Players.SelectedItem as Player;

                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to remove this player?", "Delete Player?", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    if (selectedPlayer != null)
                    {
                        playerList.Remove(selectedPlayer);
                        listBox_Players.ItemsSource = "";
                        listBox_Players.ItemsSource = playerList;
                    }
                }
            }
        }

        private void lbxDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // When the user clicks on a team in the list the players for that team will display
            Team selectedTeam = lbxDisplay.SelectedItem as Team;

            if (selectedTeam != null)
            {
                listBox_Players.ItemsSource = "";
                FilteredplayerList.Clear();

                foreach (var item in playerList)
                {
                    if (selectedTeam.TeamName == item.TeamName)
                    {
                        FilteredplayerList.Add(item);

                    }
                }
                listBox_Players.ItemsSource = FilteredplayerList;
            }
        }

        private void btn_RemoveTeam_Click(object sender, RoutedEventArgs e)
        {
            // Removing a team from the team list with verification

            Team selectedTeam = lbxDisplay.SelectedItem as Team;

            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to remove this Team?", "Delete Team?", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                if (selectedTeam != null)
                {
                    teamList.Remove(selectedTeam);
                    lbxDisplay.ItemsSource = "";
                    lbxDisplay.ItemsSource = teamList;
                }
            }
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            /*
             Here is the attempt at saving the list, I have it almost completed, however the array is out of bounds 
             
            string[] teamtxt = new string[teamList.Count];
            int totalThings = (teamList.Count + playerList.Count + managerList.Count);

            for (int i = 0; i < totalThings; i++)
            {
                
                teamtxt[i] = teamList[i].ToString();
                teamtxt[i] = playerList[i].ToString();
                teamtxt[i] = managerList[i].ToString();
            }
            File.WriteAllLines(@"footballData.txt", teamtxt);
            */
        }

        private void btn_Reset_Click(object sender, RoutedEventArgs e)
        {
            listBox_Players.ItemsSource = playerList;
        }
    }
}
