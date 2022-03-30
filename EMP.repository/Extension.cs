using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.repository
{
    public static class Extension
    {
        public static string FormatDate(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
