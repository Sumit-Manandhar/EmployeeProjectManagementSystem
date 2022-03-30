using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.model
{
    public class Project
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public DateTime Estimated_date { get; set; }
        public Decimal Budget { get; set; }
        public String Description { get; set; }

        public int UserID { get; set; }
        public User users { get; set; }

        //ID int identity primary key,
        //[Name] varchar(100),
        //EstimatedTime int,
        //EstimatedBudget decimal (20,2),
        //UsedBudget decimal (20,2),
        //[Description] varchar(100),

    }
}
