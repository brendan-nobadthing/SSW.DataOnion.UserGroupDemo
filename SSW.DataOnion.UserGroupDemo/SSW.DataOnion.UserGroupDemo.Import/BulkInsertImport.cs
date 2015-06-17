using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using SSW.Data.Interfaces;
using SSW.DataOnion.UserGroupDemo.DataInterfaces;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Import;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Repositories;
using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.Import
{
    public class BulkInsertImport : IImportStudents
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _log = Log.ForContext<ExtendedRepositoryImport>();



        public BulkInsertImport(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public void Import(IObjectDataSource<Student> dataSource)
        {
            var studentsToImport = dataSource.GetObjects();
            _log.Information("Importing {countTotal} students via bulk insert", studentsToImport.Count);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            _studentRepository.BulkInsert(studentsToImport);
            _unitOfWork.SaveChanges();

            stopwatch.Stop();
            _log.Information("Import Complete after {timeTaken} seconds", stopwatch.Elapsed.TotalSeconds);
        }
    }
}
