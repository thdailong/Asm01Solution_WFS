using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class _connect
    {
        const string connectionString = "Server=(local);uid=sa;pwd=sa123;database=assignment1;TrustServerCertificate=True;Encrypt=False";
        public static SqlConnection makeConnect()
        {
            return new SqlConnection(connectionString);
        }
    }
}
