using EMP.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EMP.repository.Interface
{
    public interface IEPRepo
    {

        List<SelectListItem> ProjectDDL();
        List<SelectListItem> EmployeeDDL();
        int insertUpdateEP(EmployeeProjectMaster master);
        List<Report> getReports(String Name);
    }
}
