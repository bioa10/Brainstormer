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

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "BrainStormer";

            IdeaManager anIdeaManager = new IdeaManager();


            // just testing to make sure the references work
            Idea anIdea = new Idea();
            anIdea.Description = "A description";

            anIdeaManager.Ideas.Add(anIdea);

            aMindMapPage.SetItemSource(anIdeaManager);



            
        }

        private void MindMap_Click(object sender, System.EventArgs e)
        {
            // used to set the displayed page
            // _mainFrame.Navigate(new MindMapPage());
            _mainFrame.Navigate(aMindMapPage);
            //_mainFrame.Navigate(new Uri("http://www.google.com/"));
        }

    }

    
}
