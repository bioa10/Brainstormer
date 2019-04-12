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
            Random randomNumberGenerator = new Random();

            DisplayIdeas();
            StartDemoButton.Visibility = Visibility.Hidden;
            RoundLabel.Content = "Round " + anIdeaTournament.RoundNumber;
            InfoLabel.Content = "Click the ideas that you want to vote for";
            VotesLeftLabel.Content = "You have X votes left";

            DemoDisplay.Text = "Tournament Demo Started";
            await Task.Delay(2000);
            DemoDisplay.Text = "Round 1";
            await Task.Delay(2000);
            // if there are at least two users to test with
            if (anIdeaTournament.UserManager.UserList.Count > 1)
            {
                int randomUser = 0;
                int randomIdea = 0;
                // while users have votes left
                while (anIdeaTournament.calculatePercentageVotesUsed() != 1)
                {
                    // note: maxValue is not actually included in the output
                    // picks a random user to vote
                    randomUser = randomNumberGenerator.Next(
                        0, anIdeaTournament.UserManager.UserList.Count);
                    
                    // if the random user has votes left
                    if(anIdeaTournament.UserManager.UserList[randomUser].VotesLeft > 0)
                    {
                        // pick a random idea to vote on
                        randomIdea = randomNumberGenerator.Next(
                        0, anIdeaTournament.IdeaManager.Ideas.Count);

                       
                        // if the user hasn't already voted on the idea
                        if(anIdeaTournament.Vote(anIdeaTournament.IdeaManager.Ideas[randomIdea], anIdeaTournament.UserManager.UserList[randomUser]) == true)
                        {
                            DemoDisplay.Text = anIdeaTournament.UserManager.UserList[randomUser].UserName + " voted for: " + anIdeaTournament.IdeaManager.Ideas[randomIdea];
                            await Task.Delay(2000);
                            DemoDisplay.Text = " ";
                        }
                    }
                    
                    await Task.Delay(500);
                    //break;
                }
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
