using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.repository
{
    public class ConnectionRepo
    {

        public string connectionStr => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

    }
}
