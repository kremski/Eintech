using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using Eintech.Controllers;
using Eintech.DAL.Models;
using Eintech.Models;
using Eintech.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EintechNUnitTest.ControllerTest
{
    public class PersonControllerTest
    {
        private string _searchString;
        private Person _peopleDal;
        private PersonViewModel _peopleViewModel;
        private Mock<IPersonService> _personService;
        private Mock<IGroupService> _groupService;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _personService = new Mock<IPersonService>();
            _groupService = new Mock<IGroupService>();
            _mapper = new Mock<IMapper>();
        }

        [Test]
        public async Task Index_When_searchStringNotEmpty_Then_SearchPeopleAsync()
        {
            // Arrange
            var fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            var id = fixture.Create<int>();
            _searchString = "abc";
            _peopleDal = fixture.Build<Person>()
                .With(x => x.Id, id)
                .With(y => y.Name, _searchString)
                .With(r => r.Group, null as Group)
                .With(g => g.GroupId, id)
                .Create();

            _peopleViewModel = fixture.Build<PersonViewModel>()
                .With(x => x.Id, id)
                .With(y => y.Name, _searchString)
                .With(r => r.Group, null as GroupViewModel)
                .With(g => g.GroupId, id)
                .Create();


            _personService
                .Setup(x => x.SearchPeopleAsync(_searchString))
                .Returns(Task.FromResult(new List<Person>{_peopleDal}));
            _mapper
                .Setup(x => x.Map<PersonViewModel>(It.IsAny<Person>()))
                .Returns(_peopleViewModel);

            var sut = new PersonController(_personService.Object, _groupService.Object, _mapper.Object);

            //Act
            var result = await sut.Index(_searchString) as ViewResult;
            var viewModels = (IEnumerable<PersonViewModel>) result.ViewData.Model;

            //Assert
            Assert.AreEqual(viewModels.FirstOrDefault().Name, _searchString);
        }

        [Test]
        public async Task Index_When_searchStringEmpty_Then_GetAllPeopleAsync()
        {
            Assert.Pass();
        }
    }
}