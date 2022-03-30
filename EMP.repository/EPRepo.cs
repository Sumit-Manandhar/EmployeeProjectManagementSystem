using EMP.core;
using EMP.model;
using EMP.repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EMP.repository
{
   public  class EPRepo:ConnectionRepo , IEPRepo
    {
        private readonly Context context;
        public EPRepo()
        {
            context = new Context();
        }
        public List<SelectListItem> EmployeeDDL()
        {
            List<SelectListItem> item = new List<SelectListItem>();
            context.Employees.ToList().ForEach(x => {
                item.Add(new SelectListItem { Text = x.FullName, Value = x.ID.ToString() });
            });
            return item;
        }
        public List<SelectListItem> ProjectDDL()
        {
            List<SelectListItem> item = new List<SelectListItem>();
            context.Projects.ToList().ForEach(x => {
                item.Add(new SelectListItem { Text = x.Name, Value = x.ID.ToString() });
            });
            return item;
        }

        //--ado.net--
        public int insertUpdateEP(EmployeeProjectMaster master)
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {

                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "spAssign";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter[] param = new SqlParameter[]

                    {
                        new SqlParameter("@ID", master.ID ),
                        new SqlParameter("@EmployeeID", master.EmployeeID),
                        new SqlParameter("@Position",master.Position ),
                        new SqlParameter("@DetailsList", master.DetailsList)

                     
                    


                    };
                    cmd.Parameters.AddRange(param);

                    int res = cmd.ExecuteNonQuery();
                    return res;
                }
            }
        }

        public List<Report> getReports(String Name )
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                List<Report> reports = new List<Report>();
                conn.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "spReport";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter[] param = new SqlParameter[]

                    {
                        new SqlParameter("@EmployeeName", Name ),
                    };
                    cmd.Parameters.AddRange(param);

                    int res = cmd.ExecuteNonQuery();


                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Report report = new Report();
                           
                            report.EmployeeCode = Convert.ToInt32(reader["EmployeeCode"]);

                            report.Employee = reader["Employee"].ToString();
                            report.Citizenship = reader["Citizenship"].ToString();
                            report.ProjectCode = Convert.ToInt32(reader["ProjectCode"]);
                            report.Project = reader["Project"].ToString();
                            report.Position =   reader["Position"].ToString();
                            report.Budget = Convert.ToDecimal(reader["Budget"]);
                            report.StartDate = Convert.ToDateTime( reader["StartDate"]).FormatDate();
                            report.EndDate = Convert.ToDateTime(reader["EndDate"]).FormatDate();
                            report.EstimatedDate = Convert.ToDateTime(reader["Estimated_date"]).FormatDate();
                            report.TimeInMonths = Convert.ToDecimal(reader["Months"]);
                            report.Description = reader["Description"].ToString();
                           



                            reports.Add(report);
                        }

                    }

                    return reports;


                }

            }
        }
    }
}
