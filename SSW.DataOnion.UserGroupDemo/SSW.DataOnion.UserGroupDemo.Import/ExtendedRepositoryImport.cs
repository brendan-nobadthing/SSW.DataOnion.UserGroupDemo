using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using SSW.DataOnion.UserGroupDemo.DataInterfaces;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Import;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Repositories;
using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.Import
{
    public class ExtendedRepositoryImport : IImportStudents
    {

        private readonly IStudentRepository _studentRepository;

        private readonly ILogger _log = Log.ForContext<ExtendedRepositoryImport>();


        public ExtendedRepositoryImport(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Import(IObjectDataSource<Student> dataSource)
        {
            var studentsToImport = dataSource.GetObjects();
            _log.Information("Importing {countTotal} students via cutom repository extension", studentsToImport.Count);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            _studentRepository.ImportStudents(dataSource.GetObjects());

            stopwatch.Stop();
            _log.Information("Import Complete after {timeTaken} seconds", stopwatch.Elapsed.TotalSeconds);
        }
    }
}
