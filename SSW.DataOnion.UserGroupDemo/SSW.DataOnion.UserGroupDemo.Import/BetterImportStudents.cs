using System.Diagnostics;
using Serilog;
using SSW.Data.Interfaces;
using SSW.DataOnion.UserGroupDemo.DataInterfaces;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Import;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Repositories;
using SSW.DataOnion.UserGroupDemo.Domain;

namespace SSW.DataOnion.UserGroupDemo.Import
{
    public class BetterImportStudents : IImportStudents
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;

        private ILogger _log = Log.ForContext<BetterImportStudents>();


        public BetterImportStudents(IStudentRepository studentRepository, 
            IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public void Import(IObjectDataSource<Student> dataSource)
        {

            int count = 0;
            var studentsToImport = dataSource.GetObjects();
            _log.Information("Importing {countTotal} students", studentsToImport.Count);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            foreach (var s in studentsToImport)
            {
                _studentRepository.Add(s);
                count++;

                if (count % 50 == 0)
                {
                    _unitOfWork.SaveChanges();
                    _unitOfWork.Dispose();
                    _log.Information("Processed {countProcessed} of {countTotal}", count, studentsToImport.Count);
                }
            }
            _unitOfWork.SaveChanges();

            stopwatch.Stop();
            _log.Information("Import Complete after {timeTaken} seconds", stopwatch.Elapsed.TotalSeconds);
        }
    }
}