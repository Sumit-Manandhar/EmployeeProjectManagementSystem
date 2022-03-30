using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.model
{
    public class Report
    {
        public int ID { get; set; }
        public int EmployeeCode { get; set; }
        public String Employee { get; set; }
        public String Citizenship { get; set; }
        public int  ProjectCode { get; set; }
        public String Project { get; set; }
        public string Position { get; set; }
        public decimal Budget { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string EstimatedDate { get; set; }
        public String Description { get; set; }
        public Decimal TimeInMonths { get; set; }


    }
}
