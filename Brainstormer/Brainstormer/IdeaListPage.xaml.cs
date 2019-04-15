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
using BrainstormerData;

namespace Brainstormer
{
    /// <summary>
    /// Interaction logic for IdeaListPage.xaml
    /// </summary>
    public partial class IdeaListPage : Page
    {
        public IdeaListPage(IdeaManager anIdeaManager, UserManager aUserManager)
        {
            InitializeComponent();
            IdeaManager = anIdeaManager;
            UserManager = aUserManager;
            IdeaViewerBox.ItemsSource = IdeaManager.Ideas;
        }

        public IdeaManager IdeaManager { get; private set; }
        public UserManager UserManager { get; private set; }

        private void IdeaViewerBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IdeaDisplay.Text = IdeaManager.Ideas[IdeaViewerBox.SelectedIndex].Description;
        }
    }
}
