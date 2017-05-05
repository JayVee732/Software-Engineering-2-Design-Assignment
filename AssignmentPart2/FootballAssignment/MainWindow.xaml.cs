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

namespace FootballAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PremFootballLeagueDBEntities db = new PremFootballLeagueDBEntities();


        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] TeamBox = { "Select Team", "Liverpool", "Chelsea", "Arsenal", "Tottenham", "West Brom", "Man United", "Man City", "Everton" };
            comboBox_Team.ItemsSource = TeamBox;
            comboBox_Team.SelectedIndex = 0;

            string[] ResultBox = { "Select Result", "Win", "Draw", "Loss"};
            comboBox_Result.ItemsSource = ResultBox;
            comboBox_Result.SelectedIndex = 0;



            var populateLeague = from t in db.TeamTBLs
                                 where t.TeamName != null
                                 orderby t.Points descending
                                 select new
                                 {
                                     Name = t.TeamName,
                                     GD = t.GoalDif,
                                     Points = t.Points
                                 };


            var sortedLeague = populateLeague.ToList();
            LeagueGrid.ItemsSource = sortedLeague;

            var PopulatePlayers = from p in db.PlayerTBLs
                                  where p.PlayerName != null
                                  orderby p.TeamName descending
                                  select new
                                  {
                                      Name = p.PlayerName,
                                      Team = p.TeamName,
                                      Shirt_Number = p.PlayerNumber,
                                      Player_Position = p.PlayerPosition
                                  };

            listBox_Players.ItemsSource = PopulatePlayers.ToList();

            var PopulateManagers = from m in db.ManagerTBLs
                                   where m.ManagerName != null
                                   orderby m.TeamName descending
                                   select new
                                   {
                                       Manager_Name = m.ManagerName,
                                       Nationality = m.ManagerNationality,
                                       Team = m.TeamName
                                   };

            lbxManagerDisplay.ItemsSource = PopulateManagers.ToList();

            var populateMatches = from x in db.MatchesTBLs
                                  where x.OpponentName != null
                                  orderby x.TeamName descending
                                  select new
                                  {
                                      League_Team = x.TeamName,
                                      Opponent = x.OpponentName
                                  };

            Txtblock_Matches.ItemsSource = populateMatches.ToList();
        }

        private void btnAddTeam_Click(object sender, RoutedEventArgs e)
        {
            var query = (from t in db.TeamTBLs
                         select t).First();

            TeamTBL newTeam = new TeamTBL
            {
                TeamName = tbxTeamName.Text,
                Points = Convert.ToInt32(tbxClubPoints.Text),
                GoalDif = Convert.ToInt32(tbxGoalDifference.Text),
                ManagerName = txtbox_Manager.Text

            };

            db.TeamTBLs.Add(newTeam);
            db.SaveChanges();

            MessageBox.Show("WORLD NEWS!!!\tNew unknown team have made a dramatic entrance into the Premier League");

        }

        private void btnAddManager_Click(object sender, RoutedEventArgs e)
        {
            var query = (from t in db.ManagerTBLs
                         select t).First();

            ManagerTBL newManager = new ManagerTBL
            {
                ManagerName = tbxMangerName.Text,
                ManagerNationality = tbxManagerNationality.Text,
                TeamName = tbxManagerTeam.Text
            };

            db.ManagerTBLs.Add(newManager);
            db.SaveChanges();

            MessageBox.Show("Premiership News! New manager signs his contact with " + tbxMangerName.Text);
        }

        private void btnRemoveManager_Click(object sender, RoutedEventArgs e)
        {
            if (lbxManagerDisplay.SelectedValue != null)
            {
                ManagerTBL selected = lbxManagerDisplay.SelectedValue as ManagerTBL;

                var removeManager = from manager in db.ManagerTBLs
                                    where manager.ManagerName == selected.ManagerName
                                    select manager;

                db.ManagerTBLs.RemoveRange(removeManager);
                db.SaveChanges();

            }

            else if (tbxTeamName.Text != null)
            {
                var removeTeam = from team in db.TeamTBLs
                                 where team.TeamName == tbxTeamName.Text
                                 select team;

                db.TeamTBLs.RemoveRange(removeTeam);
                db.SaveChanges();
            }

            else
            {
                MessageBox.Show("Please select a team from the league or input a team name into the 'Team Name:' box");
            }
        }

        private void btn_AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            var query = (from t in db.PlayerTBLs
                         select t).First();

            PlayerTBL newPlayer = new PlayerTBL
            {
                PlayerName = Player_Surname.Text,
                PlayerNationality = Player_Nationality.Text,
                PlayerNumber = Player_Number.Text,
                PlayerPosition = txtbox_PlayerPosition.Text,
                TeamName = txtbox_PlayerTeam.Text,
                TeamTBLTeamName = txtbox_PlayerTeam.Text

            };

            db.PlayerTBLs.Add(newPlayer);
            db.SaveChanges();

            MessageBox.Show("Transfer news as new wiz kid, " + Player_Surname.Text + " signs for " + txtbox_PlayerTeam);
        }

        private void btn_RemovePlayer_Click(object sender, RoutedEventArgs e)
        {

            if (listBox_Players.SelectedValue != null)
            {
                PlayerTBL selected = listBox_Players.SelectedValue as PlayerTBL;

                var removePlayer = from player in db.PlayerTBLs
                                   where player.PlayerName == selected.PlayerName
                                   select player;

                db.PlayerTBLs.RemoveRange(removePlayer);
                db.SaveChanges();

            }

            else if (Player_Surname.Text != null)
            {
                var removeTeam = from player in db.PlayerTBLs
                                 where player.PlayerName == tbxTeamName.Text
                                 select player;

                db.PlayerTBLs.RemoveRange(removeTeam);
                db.SaveChanges();
            }

            else
            {
                MessageBox.Show("Please select a team from the league or input a team name into the 'Team Name:' box");
            }
        }

        private void btn_RemoveTeam_Click(object sender, RoutedEventArgs e)
        {
            if (LeagueGrid.SelectedValue != null)
            {
                TeamTBL selected = LeagueGrid.SelectedValue as TeamTBL;

                var removeTeam = from team in db.TeamTBLs
                                 where team.TeamName == selected.TeamName
                                 select team;

                db.TeamTBLs.RemoveRange(removeTeam);
                db.SaveChanges();

            }

            else if (tbxTeamName.Text != null)
            {
                var removeTeam = from team in db.TeamTBLs
                                 where team.TeamName == tbxTeamName.Text
                                 select team;

                db.TeamTBLs.RemoveRange(removeTeam);
                db.SaveChanges();
            }

            else
            {
                MessageBox.Show("Please select a team from the league or input a team name into the 'Team Name:' box");
            }
        }

        private void LeagueGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TeamTBL selected = LeagueGrid.SelectedValue as TeamTBL;

            if (selected != null)
            {
                tbxTeamName.Text = selected.TeamName.ToString();
                tbxClubPoints.Text = selected.Points.ToString();
                tbxGoalDifference.Text = selected.GoalDif.ToString();
                txtbox_Manager.Text = selected.ManagerName.ToString();
            }
        }
    }
}
