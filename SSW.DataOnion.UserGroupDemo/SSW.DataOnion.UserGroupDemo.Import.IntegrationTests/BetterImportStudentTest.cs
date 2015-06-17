using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSW.Data.Interfaces;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Repositories;
using SSW.DataOnion.UserGroupDemo.Import.IntegrationTests.Autofac;
using Xunit;

namespace SSW.DataOnion.UserGroupDemo.Import.IntegrationTests
{
    [Collection("DataCollection")]
    public class BetterImportStudentsTest
    {

        private readonly DataFixture _dataFixture;

        public BetterImportStudentsTest(DataFixture dataFixture)
        {
            _dataFixture = dataFixture;
        }

        [Fact]
        public void DoBetterImportTest()
        {
            var studentRepository = _dataFixture.GetDependency<IStudentRepository>();
            var unitOfWork = _dataFixture.GetDependency<IUnitOfWork>();
            var importer = new BetterImportStudents(studentRepository, unitOfWork);
            importer.Import(new CsvStudentDataSource("App_Data/names.csv"));
        }

    }
}
