using System;
using System.Collections.Generic;
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
            Team t1 = new Team() { TeamName = "Heart", GoalDifference = 9, Points = 6 };
            Team t2 = new Team() { TeamName = "ManU", GoalDifference = 4, Points = 2435 };
            Team t3 = new Team() { TeamName = "Live", GoalDifference = 89, Points = 34 };
            Team t4 = new Team() { TeamName = "Arse", GoalDifference = 420, Points = 987234 };

            teamList.Add(t1);
            teamList.Add(t2);
            teamList.Add(t3);
            teamList.Add(t4);

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

            //Commits
            lbxManagerDisplay.ItemsSource = managerList;
        }
    }
}
