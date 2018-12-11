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
using CRMClient.Model;

namespace CRMClient.Views
{
    /// <summary>
    /// Interaction logic for UserListingItem.xaml
    /// </summary>
    public partial class UserListingItem : UserControl
    {
        MainWindow mainWindow;
        User user;
        public UserListingItem(MainWindow mainWindow, User user)
        {
            InitializeComponent();
            this.user = user;
            this.mainWindow = mainWindow;
            UserIDNumber.Text = user.userID.ToString();
            UserNameSurname.Text = $"{user.name} {user.surname}";
            if (user.isDeleted)
                statusDot.Fill = new SolidColorBrush(Color.FromRgb(200, 50, 30));
        }

        public User GetUser()
        {
            return user;
        }

        public delegate void ShowUserRequestEventHandler(object sender, User user);
        public event ShowUserRequestEventHandler ShowUserRequest;
        private void ShowUserRequestCall()
        {
            if (ShowUserRequest != null)
                ShowUserRequest.Invoke(this, user);
        }

        private void UserControlDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ShowUserRequestCall();
        }
    }
}
