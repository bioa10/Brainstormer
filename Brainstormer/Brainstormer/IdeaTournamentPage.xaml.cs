using BrainstormerData;
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

namespace Brainstormer
{
     

    /// <summary>
    /// Interaction logic for IdeaTournamentPage.xaml
    /// </summary>
    public partial class IdeaTournamentPage : Page
    {
        public IdeaTournamentPage(IdeaManager anIdeaManager, UserManager aUserManager)
        {
            InitializeComponent();
            anIdeaTournament = new IdeaTournament(anIdeaManager, aUserManager, false);
        }

        void DisplayIdeas()
        {
            IdeaViewerBox.ItemsSource = anIdeaTournament.IdeaManager.Ideas;
        }

        private void StartTournament_Click(object sender, RoutedEventArgs e)
        {
            // TODO: alert other users of a starting tournament

            DisplayIdeas();

            // hidden hides the button but it will still take up space
            // collapsed will collapse it so that it has zero width and height
            StartTournamentButton.Visibility = Visibility.Hidden;

            RoundLabel.Content = "Round " + anIdeaTournament.RoundNumber;
            InfoLabel.Content = "Click the ideas that you want to vote for";
            VotesLeftLabel.Content = "You have X votes left";

            //IdeaViewerBox.SelectedItem
        }

        private async void StartDemo_Click(object sender, RoutedEventArgs e)
        {
            DisplayIdeas();
            StartDemoButton.Visibility = Visibility.Hidden;
            RoundLabel.Content = "Round " + anIdeaTournament.RoundNumber;
            InfoLabel.Content = "Click the ideas that you want to vote for";
            VotesLeftLabel.Content = "You have X votes left";

            DemoDisplay.Content = "Tournament Demo Started";
            await Task.Delay(4500);
            DemoDisplay.Content = "Round 1";
            // if there are at least two users to test with
            if (anIdeaTournament.UserManager.UserList.Count > 1)
            {
                // while users have votes left
                //while (anIdeaTournament.calculatePercentageVotesUsed() != 1)
                //{

               // }
            }
        }

        private void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {

        }

        // ----- default properties -----
        private IdeaTournament anIdeaTournament { get; set; }
        private UserManager aUserManager { get; set; }

        private List<Idea> selectedIdeas { get; set; }
    }
}
