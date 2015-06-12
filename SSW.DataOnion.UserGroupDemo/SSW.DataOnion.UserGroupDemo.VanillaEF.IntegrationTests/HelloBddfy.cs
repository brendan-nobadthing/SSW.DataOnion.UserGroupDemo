using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.BDDfy;
using Xunit;

namespace SSW.DataOnion.UserGroupDemo.VanillaEF.IntegrationTests
{
    [Story(AsA = "Developer", IWant = "BDDfy Unit tests", SoThat = "Tests can match Acceptance criteria")]
    public class HelloBDDfy
    {

        public HelloBDDfy()
        {

        }

        void WhenTestsAreExecuted()
        {

        }


        private void ThenBDDfyDoesItsThing()
        {
            Assert.True(true);
        }


        [Fact]
        public void RunHelloBddfy()
        {
            this.BDDfy();
        }



    }
}
