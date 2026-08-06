using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access
{
    internal class GlobalAccesDataBase
    {
        public static string query = "server=.;database=DVLD;user Id=sa;password=123456;";
        public static SqlConnection conn = new SqlConnection(query);

    }
}

