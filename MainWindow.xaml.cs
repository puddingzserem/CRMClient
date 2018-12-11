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
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using CRMClient.Model;
using CRMClient.Controllers;
using CRMClient.Tools;
using CRMClient.Views;

namespace CRMClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
            RunAsync();
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:61311/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async void AddButtonClick(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.name = UserName.Text;
            user.surname = UserSurname.Text;
            user.birthDate = UserBirthDate.SelectedDate;
            user.login = UserLogin.Text;
            user.password = UserPassword.Text;
            user.isDeleted = false;
            Uri returnedUri = await UserController.AddUserAsync(user, client);
            RefreshUsersList();

            //List<User> users = new List<User>();
            //users = RandomUser.GenerateRandomUserList(20);
            //foreach (User user in users)
            //{
            //    MessageBox.Show($"{user.name} {user.surname}");
            //    Uri returnUri = await UserController.AddUserAsync(user, client);
            //}
        }

        async void RefreshUsersList()
        {
            List<User> users = new List<User>();
            users = await UserController.GetUsersListAsync(client);
            UsersList.Items.Clear();
            foreach (User u in users)
            {
                UserListingItem userListingItem = new UserListingItem(this, u);
                userListingItem.ShowUserRequest += DoubleClick;
                UsersList.Items.Add(userListingItem);
            }

        }

        private void ListButtonClick(object sender, RoutedEventArgs e)
        {
            RefreshUsersList();
        }

        private void NewButtonClick(object sender, RoutedEventArgs e)
        {
            UserLogin.IsEnabled = true;
            UserPassword.IsEnabled = true;
            UserName.Clear();
            UserSurname.Clear();
            UserLogin.Clear();
            UserPassword.Clear();
            UserDeleted.IsChecked = false;
            UserID.Text = null;
        }

        private void DoubleClick(object sender, User user)
        {
            UserID.Text = user.userID.ToString();
            UserName.Text = user.name;
            UserSurname.Text = user.surname;
            UserLogin.Text = user.login;
            UserPassword.Text = user.password;
            UserBirthDate.SelectedDate = user.birthDate;
            UserDeleted.IsChecked = user.isDeleted;
            UserLogin.IsEnabled = false;
            UserPassword.IsEnabled = false;
        }

        private async void UpdateButtonClick(object sender, RoutedEventArgs e)
        {
            User user = await UserController.GetUserAsync(Int32.Parse(UserID.Text), client);
            user.name = UserName.Text;
            user.surname = UserSurname.Text;
            user.birthDate = UserBirthDate.SelectedDate;
            User returnedUser = await UserController.UpdateUserAsync(user, client);
            RefreshUsersList();
        }

        private async void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            User user = await UserController.GetUserAsync(Int32.Parse(UserID.Text), client);
            User returnedUser = await UserController.DeleteUserAsync(user, client);
            RefreshUsersList();
        }
    }
}
