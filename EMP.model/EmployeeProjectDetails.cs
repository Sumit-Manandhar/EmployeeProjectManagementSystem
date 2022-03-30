using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EMP.model
{
   public class EmployeeProjectDetails
    {

        public int ID { get; set; }
        public int EmployeeProjectMasterID { get; set; }
        public EmployeeProjectMaster masters { get; set; }
        public int ProjectID { get; set; }
        //public Project projects { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [NotMapped]
        public List<SelectListItem> ProjectList { get; set; }

    }
}
