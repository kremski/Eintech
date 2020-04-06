using System.Threading.Tasks;
using NUnit.Framework;

namespace EintechNUnitTest.ServiceTest
{
    public class PersonControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllGroupsAsync_When_Empty_Then_EmptyResponse()
        {
            Assert.Pass();
        }

        [Test]
        public async Task GetAllGroupsAsync_When_CollectionNotEmpty_Then_Response()
        {
            Assert.Pass();
        }
    }
}