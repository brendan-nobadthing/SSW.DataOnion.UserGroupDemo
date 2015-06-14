using TestStack.BDDfy;
using Xunit;

namespace SSW.DataOnion.UserGroupDemo.EFDataOnion.IntTests
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
