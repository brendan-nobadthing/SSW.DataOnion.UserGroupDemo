using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSW.DataOnion.UserGroupDemo.VanillaEF.IntegrationTests
{
    public class DropDatabase
    {

        public static void DropDb()
        {
            using (
                var conn =
                    new System.Data.SqlClient.SqlConnection(
                        System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var command = conn.CreateCommand())
            {
                conn.Open();
                command.CommandText = "Use Master; Drop Database DataOnion_UserGroupDemo";
                command.ExecuteNonQuery();
            }
        }

    }
}
