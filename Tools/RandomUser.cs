using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMClient.Model;

namespace CRMClient.Tools
{
    public static class RandomUser
    {
        static Random random = new Random();

        #region Random Data
        static string[] names =
        {
            "Oneida",
            "Kayleen",
            "Denisse",
            "Kaycee",
            "Belle",
            "Jaleesa",
            "Charline",
            "Jerilyn",
            "Tyra",
            "Joellen",
            "Tereasa",
            "Oralee",
            "Anita",
            "Jacquelynn",
            "Deonna",
            "Malika",
            "Letty",
            "Sharda",
            "Lea",
            "Pattie",
            "Garry",
            "Claudio",
            "Vernon",
            "Art",
            "Matthew",
            "Jeffery",
            "Brandon",
            "Tracy",
            "Willard",
            "Giovanni",
            "Faustino",
            "Theron",
            "Rick",
            "Rudolf",
            "Waylon",
            "Dee",
            "Kasey",
            "Lazaro",
            "Darrel",
            "Filip"};
        static string[] surnames =
        {
            "Huff",
            "Hardin",
            "Massey",
            "Yoder",
            "Beasley",
            "Garrison",
            "Snyder",
            "Saunders",
            "Brooks",
            "Mcmahon",
            "Rosales",
            "Watts",
            "Shelton",
            "Melton",
            "Roberson",
            "Sanford",
            "Compton",
            "Roach",
            "Oneill",
            "Gallegos",
            "Webb",
            "Grant",
            "Gentry",
            "David",
            "Ward",
            "Lawrence",
            "Blair",
            "Cooke",
            "Fisher",
            "Norris",
            "Gomez",
            "Campos",
            "Gill",
            "Jordan",
            "Brandt",
            "Turner",
            "Thornton",
            "Hoover",
            "Maddox",
            "Schaefer"
        };
        static string passwordCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwz1234567890!@#$%&?";
        static string loginCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwz1234567890";

        #endregion
        public static List<User> GenerateRandomUserList(int count)
        {
            List<User> users = new List<User>();
            for (int i = 0; i < count; i++)
            {
                User user = new User();
                user.name = names[random.Next(0, 40)];
                user.surname = surnames[random.Next(0, 40)];
                user.birthDate = GenerateRandomDate();
                user.isDeleted = false;
                user.login = GenerateRandomLogin(i, user.name);
                user.password = GenerateRandomPassword();
                users.Add(user);
            }
            return users;
        }
        static DateTime GenerateRandomDate()
        {
            int year = random.Next(1945, 2005);
            int month = random.Next(1, 12);
            int day = DateTime.DaysInMonth(year, month);
            int Day = random.Next(1, day);
            DateTime date = new DateTime(year, month, Day);
            return date;
        }
        static String GenerateRandomPassword()
        {
            var password = new char[random.Next(8, 16)];

            for (int i = 0; i < password.Length; i++)
            {
                password[i] = passwordCharacters[random.Next(passwordCharacters.Length)];
            }

            String pass = new String(password);
            return pass;
        }
        static String GenerateRandomLogin(int index, string name)
        {
            var randomSet = new char[random.Next(2, 5)];

            for (int i = 0; i < randomSet.Length; i++)
            {
                randomSet[i] = loginCharacters[random.Next(loginCharacters.Length)];
            }

            String login = new String(randomSet);
            login = name + login + index;
            return login;
        }
    }
}
