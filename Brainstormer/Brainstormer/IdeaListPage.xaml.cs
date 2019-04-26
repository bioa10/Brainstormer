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
        


        public enum buttonType{ Idea, Comment, ProCon }

        public IdeaListPage(IdeaManager anIdeaManager, UserManager aUserManager)
        {
            InitializeComponent();
            IdeaManager = anIdeaManager;
            UserManager = aUserManager;
            CurrentButtonType = buttonType.Idea;
            IdeaViewerBox.ItemsSource = IdeaManager.Ideas;
        }

        public IdeaManager IdeaManager { get; private set; }
        public UserManager UserManager { get; private set; }
        public buttonType CurrentButtonType { get; private set; }

        private void IdeaViewerBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            IdeaDisplay.Text = IdeaManager.Ideas[IdeaViewerBox.SelectedIndex].Description;
            CommentViewerBox.ItemsSource = IdeaManager.Ideas[IdeaViewerBox.SelectedIndex].Comments;
            ProConViewerBox.ItemsSource = IdeaManager.Ideas[IdeaViewerBox.SelectedIndex].ProCons;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FocusChanged(object sender, RoutedEventArgs e)
        {
            if (sender.GetType() != typeof(ListBox))
            {
                throw new ArgumentException("Invalid Sender");
            }

            ListBox senderAsListBox = (ListBox)sender;

            switch (senderAsListBox.Name)
            {
                case "IdeaViewerBox":
                    SetButtons(buttonType.Idea);
                    break;
                case "CommentViewerBox":
                    SetButtons(buttonType.Comment);
                    break;
                case "ProConViewerBox":
                    SetButtons(buttonType.ProCon);
                    break;
                default:
                    throw new ArgumentException("Unknown ListBox");
            }
        }

        private void SetButtons(buttonType type)
        {
            CurrentButtonType = type;
            AddButton.Content = "Add " + type.ToString();
            EditButton.Content = "Edit " + type.ToString();
            DeleteButton.Content = "Delete " + type.ToString();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            AddItem add = new AddItem(IdeaManager, UserManager.UserList[0], CurrentButtonType, IdeaViewerBox, CommentViewerBox, ProConViewerBox);
            add.Show();

        }
        
    }
}
