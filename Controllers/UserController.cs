using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using CRMClient.Model;

namespace CRMClient.Controllers
{
    static class UserController
    {
        public static async Task<User> GetUserAsync(int id, HttpClient client)
        {
            User user = null;
            HttpResponseMessage response = await client.GetAsync($"api/Users/{id}");
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }
            return user;
        }

        public static async Task<Uri> AddUserAsync(User user, HttpClient client)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/Users", user);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public static async Task<List<User>> GetUsersListAsync(HttpClient client)
        {
            List<User> users = new List<User>();
            HttpResponseMessage response = await client.GetAsync($"api/Users");
            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadAsAsync<List<User>>();
            }
            return users;
        }

        public static async Task<User> UpdateUserAsync(User user, HttpClient client)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/Users/{user.userID}", user);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            user = await response.Content.ReadAsAsync<User>();
            return user;
        }

        public static async Task<User> DeleteUserAsync(User user, HttpClient client)
        {
            user.isDeleted = true;
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"api/Users/{user.userID}", user);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            user = await response.Content.ReadAsAsync<User>();
            return user;
        }
    }
}
