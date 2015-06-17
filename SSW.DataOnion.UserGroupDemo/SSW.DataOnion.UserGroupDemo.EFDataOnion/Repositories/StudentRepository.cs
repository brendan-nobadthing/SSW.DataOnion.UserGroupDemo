using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.EFDataOnion.Repositories
{
    public partial class StudentRepository
    {
        public void ImportStudents(IEnumerable<Student> students)
        {

            var connection = new SqlConnection(this.Context.Database.Connection.ConnectionString);
            using (connection)
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    "Insert into students (FirstName, LastName, Email) values (@FirstName, @LastName, @Email)";

                command.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100);
                command.Parameters.Add("@LastName", SqlDbType.NVarChar, 100);
                command.Parameters.Add("@Email", SqlDbType.NVarChar, 100);

                command.Prepare();

           
                foreach (var student in students)
                {
                    command.Parameters["@FirstName"].Value = student.FirstName;
                    command.Parameters["@LastName"].Value = student.LastName;
                    command.Parameters["@Email"].Value = student.Email;

                    command.ExecuteNonQuery();
                }

            }
            

        }
    }
}
