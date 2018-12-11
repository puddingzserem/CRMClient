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
        static HttpClient client = new HttpClient();

        public static async Task<User> GetUserAsync(int id)
        {
            User user = null;
            HttpResponseMessage response = await client.GetAsync($"api/Users/{id}");
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }
            return user;
        }

        public static async Task<Uri> AddUserAsync(User user)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/Users", user);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }
    }
}
