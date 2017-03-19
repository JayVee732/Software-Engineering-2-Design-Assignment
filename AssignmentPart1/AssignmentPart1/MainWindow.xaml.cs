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

namespace AssignmentPart1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Team> teamList = new List<Team>();
        public List<Manager> managerList = new List<Manager>();
        List<string> saveDataList = new List<string>();

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

            //teamList.Add(t1);
            //teamList.Add(t2);
            //teamList.Add(t3);
            //teamList.Add(t4);
            //teamList.Add(t5);

            lbxDisplay.ItemsSource = teamList;
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
                managerList.Clear();
                teamList.Clear();

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
        }
    }
}
