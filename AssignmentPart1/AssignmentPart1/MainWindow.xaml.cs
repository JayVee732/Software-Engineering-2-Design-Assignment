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
        public List<Team> teamDisplay = new List<Team>();
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //string[] playerType = { "Make A Selection", "Football Player", "Manager" };
            //cbxPlayerSelection.ItemsSource = playerType;
            //cbxPlayerSelection.SelectedIndex = 0;

            Team t1 = new Team() { TeamName = "Heart", GoalDifference = 9, Points = 6 };
            Team t2 = new Team() { TeamName = "ManU", GoalDifference = 4, Points = 2435 };
            Team t3 = new Team() { TeamName = "Live", GoalDifference = 89, Points = 34 };
            Team t4 = new Team() { TeamName = "Arse", GoalDifference = 420, Points = 987234 };

            teamDisplay.Add(t1);
            teamDisplay.Add(t2);
            teamDisplay.Add(t3);
            teamDisplay.Add(t4);

            lbxDisplay.ItemsSource = teamDisplay;
        }

        private void btnAddTeam_Click(object sender, RoutedEventArgs e)
        {
            lbxDisplay.ItemsSource = "";

            teamDisplay.Add(new Team() { TeamName = tbxTeamName.ToString(), GoalDifference = int.Parse(tbxGoalDifference.ToString()), Points = int.Parse(tbxClubPoints.ToString()) });

            lbxDisplay.ItemsSource = teamDisplay;
        }
        
    }
}
