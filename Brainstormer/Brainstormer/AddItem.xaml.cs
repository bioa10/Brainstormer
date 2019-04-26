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
using System.Windows.Shapes;
using BrainstormerData;

namespace Brainstormer
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        public AddItem(IdeaManager ideaManager, User user, IdeaListPage.buttonType type, ListBox ideaList, ListBox commentList, ListBox proConList)
        {
            InitializeComponent();
            IdeaManager = ideaManager;
            User = user;
            IdeaListBox = ideaList;
            CommentListBox = commentList;
            Type = type;

            switch(Type)
            {
                case IdeaListPage.buttonType.Idea:
                    IdeaDescription.Visibility = Visibility.Visible;
                    IdeaDescriptionLabel.Visibility = Visibility.Visible;
                    IdeaName.Visibility = Visibility.Visible;
                    IdeaNameLabel.Visibility = Visibility.Visible;
                    break;
                case IdeaListPage.buttonType.Comment:
                    CommentDescription.Visibility = Visibility.Visible;
                    CommentDescriptionLabel.Visibility = Visibility.Visible;
                    break;
                case IdeaListPage.buttonType.ProCon:
                    ProConDescription.Visibility = Visibility.Visible;
                    ProConDescriptionLabel.Visibility = Visibility.Visible;
                    ProConName.Visibility = Visibility.Visible;
                    ProConNameLabel.Visibility = Visibility.Visible;
                    Pro.Visibility = Visibility.Visible;
                    Con.Visibility = Visibility.Visible;
                    break;
            }
        }

        private IdeaManager IdeaManager { get; set;}
        private User User { get; set; }
        private ListBox IdeaListBox { get; set; }
        private ListBox CommentListBox { get; set; }
        private ListBox ProConListBox { get; set; }
        private IdeaListPage.buttonType Type { get; set; }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            switch (Type)
            {
                case IdeaListPage.buttonType.Idea:
                    IdeaManager.Ideas.Add(new Idea(IdeaName.Text, IdeaDescription.Text, User));
                    IdeaListBox.Items.Refresh();
                    Close();
                    break;
                case IdeaListPage.buttonType.Comment:
                    IdeaManager.Ideas[IdeaListBox.SelectedIndex].Comments.Add(new Comment(CommentDescription.Text, User));
                    CommentListBox.Items.Refresh();
                    Close();
                    break;
                case IdeaListPage.buttonType.ProCon:
                    IdeaManager.Ideas[IdeaListBox.SelectedIndex].ProCons.Add(new ProCon(ProConName.Text,ProConDescription.Text,User, Pro.IsEnabled));
                    ProConListBox.Items.Refresh();
                    Close();
                    break;
            }
        }
    }
}
