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

            scaleX = 1;
            scaleY = 1;

            int fieldHeight = 1000;
            int fieldWidth = 1000;

            int fieldX = -1;
            int fieldY = -1;

            FieldBorder.Height = fieldHeight;
            FieldBorder.Width = fieldWidth;

            // first two values are distance from left, and top side of window
            MindMapField.Margin = new Thickness(fieldX, fieldY, 0, 0);

            MindMapField.Height = fieldHeight;
            MindMapField.Width = fieldWidth;
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
            // ellipse.Width = position.X;
            // ellipse.Height = position.Y;

            DebugInfoBox.Items.Clear();
            DebugInfoBox.Items.Add("Debug Info: ");
            DebugInfoBox.Items.Add("-- Mouse X and Y --");
            DebugInfoBox.Items.Add(position.X);
            DebugInfoBox.Items.Add(position.Y);
        }

        double scaleRate = 1.15;
        // private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        private void Page_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                scaleX *= scaleRate;
                scaleY *= scaleRate;
             
                // TODO: possibly use the cursor position as the zoom center, instead of the center of the field
                ScaleTransform scaleTransform1 = new ScaleTransform(scaleX, scaleY, Width / 2, Height / 2);
                MindMapField.RenderTransform = scaleTransform1;
            }
            else
            {
                scaleX /= scaleRate;
                scaleY /= scaleRate;
               
                ScaleTransform scaleTransform1 = new ScaleTransform(scaleX, scaleY, Width/2, Height/2);
                MindMapField.RenderTransform = scaleTransform1;
            }
        }

        public double scaleX { get; set; }
        public double scaleY { get; set; }
    }
}