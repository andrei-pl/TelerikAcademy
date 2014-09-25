namespace MongoChatClient
{
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

    using MongoChat.Models;

    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            this.InitializeComponent();
            this.txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text != "")
            {
                var username = this.txtUsername.Text;

                this.Hide();
                this.ShowChatWindow(username);
                this.Close();
            }
            else
            {
                MessageBox.Show("The username is invalid!");
            }
        }

        private void ShowChatWindow(string username)
        {
            var user = new UserSession(username);
            var mainWindow = new ChatWindow(user);
            mainWindow.Show();
        }
    }
}
