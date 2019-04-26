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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Back_To_Login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
        }

        private void Create_Account_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password.ToString() != ConfirmPasswordBox.Password.ToString())
            {
                Status.Foreground = Brushes.Crimson;
                Status.Text = "The passwords you entered do not match. Try again.";
            }
            else if (PasswordBox.Password.Length < 6)
            {
                Status.Foreground = Brushes.Crimson;
                Status.Text = "The password must be at least 6 characters long. Try again.";
            }
            else if(UserNameBox.Text.Length < 1)
            {
                Status.Foreground = Brushes.Crimson;
                Status.Text = "You must enter a username. Try again.";
            }
            else
            {
                Status.Foreground = Brushes.DarkGreen;
                Status.Text = "Account creation successful!";

                FileManager aFileManager = new FileManager();
                
            }
           
        }

    }
}
