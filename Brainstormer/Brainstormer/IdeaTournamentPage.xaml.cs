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

        // async so that await delay works
        private async void StartDemo_Click(object sender, RoutedEventArgs e)
        {
            // initializes random number generator for voting on random ideas
            Random randomNumberGenerator = new Random();

            DisplayIdeas();

            StartDemoButton.Visibility = Visibility.Hidden;
            StartTournamentButton.Visibility = Visibility.Hidden;

            DemoDisplay.Text = "Tournament Demo Started";
            await Task.Delay(2000);
            DemoDisplay.Text = "Ideas colored red are in danger of being removed";
            await Task.Delay(3000);

            while (anIdeaTournament.IdeaManager.Ideas.Count > 0)
            {
                anIdeaTournament.StartRound();

                // update the listbox so that it shows colors changing
                IdeaViewerBox.Items.Refresh();
                await Task.Delay(1500);

                RoundLabel.Content = "Round " + anIdeaTournament.RoundNumber;
                DemoDisplay.Text = "Round " + anIdeaTournament.RoundNumber + " Started";

                await Task.Delay(1500);

                // make sure there are at least two users to test with
                if (anIdeaTournament.UserManager.UserList.Count < 2)
                {
                    break;
                }

                // stores random numbers for choices
                int randomUser;
                int randomIdea;

                // while users have votes left
                while (anIdeaTournament.CalculatePercentageVotesUsed() != 1)
                {
                    // update the listbox so that it shows colors changing
                    IdeaViewerBox.Items.Refresh();

                    // note: maxValue is not actually included in the output
                    // picks a random user to vote
                    randomUser = randomNumberGenerator.Next(
                        0, anIdeaTournament.UserManager.UserList.Count);

                    // if the random user has votes left
                    if (anIdeaTournament.UserManager.UserList[randomUser].VotesLeft > 0)
                    {
                        // pick a random idea to vote on
                        randomIdea = randomNumberGenerator.Next(
                        0, anIdeaTournament.IdeaManager.Ideas.Count);

                        // if the user hasn't already voted on the idea
                        if (anIdeaTournament.Vote(anIdeaTournament.IdeaManager.Ideas[randomIdea],
                            anIdeaTournament.UserManager.UserList[randomUser]) == true)
                        {
                            DemoDisplay.Text =
                                anIdeaTournament.UserManager.UserList[randomUser].UserName + 
                                " voted for: " + anIdeaTournament.IdeaManager.Ideas[randomIdea];
                            await Task.Delay(2500);
                            DemoDisplay.Text = " ";
                        }
                    }

                    await Task.Delay(300);
                   
                    VotePercentLabel.Content =
                        Math.Round(anIdeaTournament.CalculatePercentageVotesUsed(), 4)
                        * 100 + "% of votes are in";
                }

                DemoDisplay.Text = "Round " + anIdeaTournament.RoundNumber + " Ended";
                await Task.Delay(1500);

                DemoDisplay.Text = "Trimming Ideas";
                anIdeaTournament.TrimIdeas();

                // if there is an idea with more votes, declare the winner
                if(anIdeaTournament.IdeaManager.Ideas.Count == 2)
                {
                    if(anIdeaTournament.IdeaManager.Ideas[0].Votes >
                        anIdeaTournament.IdeaManager.Ideas[1].Votes)
                    {
                        DemoDisplay.Text = "Winner: " +
                            anIdeaTournament.IdeaManager.Ideas[0].Name;
                        break;
                    }
                    else if(anIdeaTournament.IdeaManager.Ideas[0].Votes <
                        anIdeaTournament.IdeaManager.Ideas[1].Votes)
                    {
                        DemoDisplay.Text = "Winner: " + anIdeaTournament.IdeaManager.Ideas[1].Name;
                        break;
                    }
                    else
                    {
                        DemoDisplay.Text = "Tie!";
                    }
                }
                else if(anIdeaTournament.IdeaManager.Ideas.Count == 1)
                {
                    DemoDisplay.Text = "Winner: " + anIdeaTournament.IdeaManager.Ideas[0].Name;
                    break;
                }
            }

            // gives back the hidden buttons
            StartDemoButton.Visibility = Visibility.Visible;
            StartTournamentButton.Visibility = Visibility.Visible;
        }

        private void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {

        }

        // ----- default properties -----
        private IdeaTournament anIdeaTournament { get; set; }
        private UserManager aUserManager { get; set; }

        private List<Idea> selectedIdeas { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FileReader aFileReader;
        }
    }
}
