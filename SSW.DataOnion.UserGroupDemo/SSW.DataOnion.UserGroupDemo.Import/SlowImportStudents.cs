using System.Diagnostics;
using Serilog;
using SSW.Data.Interfaces;
using SSW.DataOnion.UserGroupDemo.DataInterfaces;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Import;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Repositories;
using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.Import
{
    public class SlowImportStudents : IImportStudents
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        private ILogger _log = Log.ForContext<SlowImportStudents>();

        public SlowImportStudents(IStudentRepository studentRepository, 
            IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public void Import(IObjectDataSource<Student> dataSource)
        {
            var studentsToImport = dataSource.GetObjects();
            _log.Information("Importing {countTotal} students", studentsToImport.Count);
            
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            
            foreach (var s in studentsToImport)
            {
                _studentRepository.Add(s);     
  
            }
            _log.Information("calling saveChanges");
            _unitOfWork.SaveChanges();
            stopwatch.Stop();
            _log.Information("import complete after {timeTaken} seconds", stopwatch.Elapsed.TotalSeconds);

        }
    }
}