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
    /// Interaction logic for MindMapPage.xaml
    /// </summary>
    public partial class MindMapPage : Page
    {
        public MindMapPage()
        {
            InitializeComponent();
            
           
        }
        public void SetItemSource(IdeaManager im)
        {
            //MindMapListBox.ItemsSource = im.Container;
            MindMapListBox.ItemsSource = im.Container;
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
