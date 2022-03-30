using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EMP.model
{
    public class EmployeeProjectMaster
    {

        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public Employee employees { get; set; }

        public String Position { get; set; }

        [NotMapped]
        public List<SelectListItem> EmployeeList { get; set; }

        [NotMapped]
        public List<EmployeeProjectDetails> DetailsList { get; set; }
        
    }
}
