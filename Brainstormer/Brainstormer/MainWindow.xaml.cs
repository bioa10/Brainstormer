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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MindMapPage aMindMapPage = new MindMapPage();
        IdeaListPage anIdeaListPage = new IdeaListPage();
        IdeaTournamentPage anIdeaTournamentPage = new IdeaTournamentPage();

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "BrainStormer";

            IdeaManager anIdeaManager = new IdeaManager();

            FileReader aFileReader = new FileReader();
            aFileReader.GetData(ref anIdeaManager);

            aMindMapPage.SetItemSource(anIdeaManager.Ideas);
        }

        private void MindMap_Click(object sender, System.EventArgs e)
        {
            // used to set the displayed page
            _mainFrame.Navigate(aMindMapPage);
            //_mainFrame.Navigate(new Uri("http://www.google.com/"));
        }

        private void Idea_List_Click(object sender, System.EventArgs e)
        {
            // used to set the displayed page
            _mainFrame.Navigate(anIdeaListPage);
        }

        private void Idea_Tournament_Click(object sender, System.EventArgs e)
        {
            // used to set the displayed page
            _mainFrame.Navigate(anIdeaTournamentPage);
           
        }
    }
}
