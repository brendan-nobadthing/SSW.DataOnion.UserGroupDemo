using System;
using System.Collections.Generic;
using System.IO;
using SSW.DataOnion.UserGroupDemo.DataInterfaces;
using SSW.DataOnion.UserGroupDemo.Domain;
using LumenWorks.Framework.IO.Csv;

namespace SSW.DataOnion.UserGroupDemo.Import
{
    public class CsvStudentDataSource : IObjectDataSource<Student>
    {
        private readonly string _fileName;
        
        public CsvStudentDataSource(string fileName)
        {
            _fileName = fileName;
        }


        public IList<Student> GetObjects()
        {
            var result = new List<Student>();

            using (CsvReader csv = new CsvReader(new StreamReader(_fileName), true))
            {
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();

                if (fieldCount != 3 || headers[0] != "FirstName")
                {
                    throw new FormatException("input csv file does not match the expected format");
                }

                while (csv.ReadNextRecord())
                {
                    result.Add(new Student()
                    {
                        FirstName = csv["FirstName"],
                        LastName = csv["LastName"],
                        Email = csv["Email"]
                    });
                }
            }
            return result;
        }



    }
}