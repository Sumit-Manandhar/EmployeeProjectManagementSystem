using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.model
{
   public  class Employee
    {
        public int ID { get; set; }
        public String FullName { get; set; }
        public string Email { get; set; }
        public String Phone { get; set; }
        public String Address { get; set; }
        public String Citizenship { get; set; }
        public DateTime DOB { get; set; }

        public int GenderID { get; set; }
        public int UsersID { get; set; }
        public User Users { get; set; }
    }
}
