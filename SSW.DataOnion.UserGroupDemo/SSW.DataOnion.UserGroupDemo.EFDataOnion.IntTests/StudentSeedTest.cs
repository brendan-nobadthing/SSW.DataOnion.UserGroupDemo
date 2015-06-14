using System.Collections.Generic;
using SSW.DataOnion.UserGroupDemo.DataInterfaces.Repositories;
using SSW.DataOnion.UserGroupDemo.Domain;
using SSW.DataOnion.UserGroupDemo.EFDataOnion.IntTests.Autofac;
using TestStack.BDDfy;
using Xunit;

namespace SSW.DataOnion.UserGroupDemo.EFDataOnion.IntTests
{

    [Story(AsA = "Developer", IWant = "Students table to be seeded with data")]
    [Collection("DataCollection")]
    public class StudentSeedTest
    {

        private readonly DataFixture _dataFixture;
        private IStudentRepository _studentRepository;

        public StudentSeedTest(DataFixture dataFixture)
        {
            _dataFixture = dataFixture;
            
        }

        private void WhenIGetStudentRepository()
        {
            _studentRepository = _dataFixture.GetDependency<IStudentRepository>();
        }

        private void ThenRepositoryIsProvided()
        {
            Assert.NotNull(_studentRepository);
        }

        private void AndThenTableHasBeenSeededWithData()
        {
            Assert.NotEmpty(_studentRepository.Get());
        }



        [Fact]
        public void Run()
        {
            this.BDDfy();
        }

    }
}
