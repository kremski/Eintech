using System.Threading.Tasks;
using NUnit.Framework;

namespace EintechNUnitTest.ServiceTest
{
    public class PersonServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllPeopleAsync_When_Empty_Then_EmptyResponse()
        {
            Assert.Pass();
        }

        [Test]
        public async Task GetAllPeopleAsync_When_CollectionNotEmpty_Then_Response()
        {
            Assert.Pass();
        }

        [Test]
        public async Task AddPersonAsync_When_ModelEmpty_Then_ReturnZero()
        {
            Assert.Pass();
        }

        [Test]
        public async Task AddPersonAsync_When_ModelNotEmpty_Then_ReturnNewPersonId()
        {
            Assert.Pass();
        }

        [Test]
        public async Task SearchPeopleAsync_When_SearchStringEmpty_Then_EmptyResponse()
        {
            Assert.Pass();
        }

        [Test]
        public async Task SearchPeopleAsync_When_SearchStringNotEmpty_Then_Response()
        {
            Assert.Pass();
        }
    }
}