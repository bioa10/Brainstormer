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
    ///
    public partial class MindMapPage : Page
    {
        //MindMap myMindMap = new MindMap();

        public MindMapPage()
        {
            InitializeComponent();
            
        }
        
        public void SetItemSource(List<Idea> ideas)
        {
            MindMapListBox.ItemsSource = ideas;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void MindMapListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            // Get the x and y coordinates of the mouse pointer.
            System.Windows.Point position = e.GetPosition(this);


            // playing with shapes and testing the mouse move handler
            ellipse.Width = position.X;
            ellipse.Height = position.Y;


            DebugInfoBox.Items.Clear();
            DebugInfoBox.Items.Add("Debug Info: ");
            DebugInfoBox.Items.Add("-- Mouse X and Y --");
            DebugInfoBox.Items.Add(position.X);
            DebugInfoBox.Items.Add(position.Y);
            
        }
    }
}
