using AutoMapper;
using Eintech.DAL.Models;
using Eintech.Models;
using Eintech.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eintech.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IGroupService groupService, IMapper mapper)
        {
            _personService = personService;
            _groupService = groupService;
            _mapper = mapper;
        }

        // GET: Person
        public async Task<IActionResult> Index(string searchString)
        {
            List<Person> people;

            if (!string.IsNullOrEmpty(searchString))
            {
                people = await _personService.SearchPeopleAsync(searchString);
                ViewData["searchString"] = searchString;
            }
            else
                people = await _personService.GetAllPeopleAsync();

            var peopleVm = people.Select(person => _mapper.Map<PersonViewModel>(person));

            return View(peopleVm);
        }

        // GET: Person/Create
        public async Task<IActionResult> Create()
        {
            var groups = await _groupService.GetAllGroupsAsync();
            var personVm = new PersonViewModel(groups.AsEnumerable());
            return View(personVm);
        }

        // POST: Person/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PersonViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                model.DateAdded = DateTime.Now;
                var newPersonId = await _personService.AddPersonAsync(_mapper.Map<Person>(model)); 
                // new Person Id can be used in consecutive action if needed

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
