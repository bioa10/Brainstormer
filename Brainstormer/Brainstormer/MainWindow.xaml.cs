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
        IdeaTournamentPage anIdeaTournamentPage;

        // tracks what the current page is to know which one the keyboard should act on
        string currentPage;

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "BrainStormer";

            // create Idea and User manager objects
            IdeaManager anIdeaManager = new IdeaManager();
            UserManager aUserManager = new UserManager();

            // create FileReader object
            FileReader aFileReader = new FileReader();

            // read data from local files into the managers
            aFileReader.GetData(anIdeaManager);
            aFileReader.GetData(aUserManager);

            // initializes the idea tournament page
            anIdeaTournamentPage = new IdeaTournamentPage(anIdeaManager, aUserManager);

            aMindMapPage.SetItemSource(anIdeaManager.Ideas);
        }

        private void MindMap_Click(object sender, System.EventArgs e)
        {
            // used to set the displayed page
            _mainFrame.Navigate(aMindMapPage);
            currentPage = "mindmap";

            // this thing can also browse the web
            //_mainFrame.Navigate(new Uri("http://www.google.com/"));
        }

        private void Idea_List_Click(object sender, System.EventArgs e)
        {
            // used to set the displayed page
            _mainFrame.Navigate(anIdeaListPage);
            currentPage = "ideaList";
        }

        private void Idea_Tournament_Click(object sender, System.EventArgs e)
        {
            // used to set the displayed page
            _mainFrame.Navigate(anIdeaTournamentPage);
            currentPage = "ideaTournament";
        }

        // keyboard controls for the mindmap
        // this seems kinda hacky but it does the job
        // may want to revisit it at a later time
        // this is here and not inside MindMapPage because the keydown event doesn't
        // make it to the page
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //aMindMapPage.DebugInfoBox.Items.Clear();
            //aMindMapPage.DebugInfoBox.Items.Add("Key pressed");

            if (currentPage == "mindmap")
            {
                if (e.Key == Key.Up)
                {
                    aMindMapPage.MindMapField.Margin = new Thickness(
                        aMindMapPage.MindMapField.Margin.Left,
                        aMindMapPage.MindMapField.Margin.Top + 18, 0, 0);
                }
                if (e.Key == Key.Left)
                {
                    aMindMapPage.MindMapField.Margin = new Thickness(
                        aMindMapPage.MindMapField.Margin.Left + 18,
                        aMindMapPage.MindMapField.Margin.Top, 0, 0);
                }
                if (e.Key == Key.Right)
                {
                    aMindMapPage.MindMapField.Margin = new Thickness(
                        aMindMapPage.MindMapField.Margin.Left - 18,
                        aMindMapPage.MindMapField.Margin.Top, 0, 0);
                }
                if (e.Key == Key.Down)
                {
                    aMindMapPage.MindMapField.Margin = new Thickness(
                        aMindMapPage.MindMapField.Margin.Left,
                        aMindMapPage.MindMapField.Margin.Top - 18, 0, 0);
                }
            }
        }
    }
}
