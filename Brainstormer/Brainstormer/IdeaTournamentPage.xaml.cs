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
        public IdeaTournamentPage()
        {
            InitializeComponent();
            
        }

        // this must be called before the page becomes functional
        public void GetIdeaManager(IdeaManager anIdeaManager)
        {
            anIdeaTournament = new IdeaTournament(anIdeaManager);
        }

        void DisplayIdeas()
        {
            IdeaViewerBox.ItemsSource = anIdeaTournament.anIdeaManager.Ideas;
        }

        private void StartTournament_Click(object sender, RoutedEventArgs e)
        {
            // TODO: alert other users of a starting tournament

            DisplayIdeas();

            // Hidden hides the button but it will still take up space
            // Collapsed will collapse it so that it has zero width and height
            StartTournamentButton.Visibility = Visibility.Hidden;

            RoundLabel.Content = "Round 1";
            InfoLabel.Content = "Click the ideas that you want to vote for";
            VotesLeftLabel.Content = "You have X votes left";

            //IdeaViewerBox.SelectedItem
        }

      
        


        private void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        // ----- default properties -----
        private IdeaTournament anIdeaTournament { get; set; }

        private List<Idea> selectedIdeas { get; set; }
    }
}
