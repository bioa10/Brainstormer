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
            anIdeaTournament = new IdeaTournament(anIdeaManager,aUserMananger, false);
        }

        void DisplayIdeas()
        {
            IdeaViewer.ItemsSource = anIdeaTournament.IdeaManager.Ideas;
        }

        private void StartTournament_Click(object sender, RoutedEventArgs e)
        {
            // alert other users of a starting tournament
            DisplayIdeas();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        // ----- default properties -----
        private IdeaTournament anIdeaTournament { get; set; }
        private UserManager aUserMananger { get; set; }
    }
}
