using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMClient.Model
{
    public class User
    {
        public int userID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime? birthDate { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public bool isDeleted { get; set; }
    }
}
