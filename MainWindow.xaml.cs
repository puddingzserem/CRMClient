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


        //static async Task<List<User>> GetUsersListAsync(string path)
        //{
        //    User user = null;
        //    HttpResponseMessage response = await client.GetAsync(path);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        user = await response.Content.ReadAsAsync<User>();
        //    }
        //    return user;
        //}



        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user.name = UserName.Text;
            user.surname = UserSurname.Text;
            user.birthDate = UserBirthDate.SelectedDate;
            user.login = UserLogin.Text;
            user.password = UserPassword.Text;
            user.isDeleted = false;
            UserController.AddUserAsync(user);

            //List<User> users = new List<User>();
            //users = RandomUser.GenerateRandomUserList(20);
            //foreach(User user in users)
            //{
            //    MessageBox.Show($"{user.name} {user.surname}");
            //    UserController.AddUserAsync(user);
            //}
        }

        private async Task ListButtonClick(object sender, RoutedEventArgs e)
        {
            User user = new User();
            user = await UserController.GetUserAsync(1);
            UsersList.Items.Add(user.name);
        }
    }
}
