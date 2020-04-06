using Eintech.DAL;
using Eintech.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eintech.Service
{
    public interface IPersonService
    {
        Task<int> AddPersonAsync(Person person);
        Task<List<Person>> GetAllPeopleAsync();
        Task<List<Person>> SearchPeopleAsync(string searchString);
    }

    public class PersonService : IPersonService
    {
        private readonly EintechDbContext _context;

        public PersonService(EintechDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddPersonAsync(Person person)
        {
            if (person == null)
                return 0;

            var newPerson = await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();
            return newPerson.Entity.Id;
        }

        public async Task<List<Person>> GetAllPeopleAsync()
        {
            return await _context.People
                    .AsNoTracking()
                    .Include(g => g.Group)
                    .ToListAsync();
        }

        public async Task<List<Person>> SearchPeopleAsync(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return null;

            return await _context.People
                    .AsNoTracking()
                    .Where(s => s.Name.Contains(searchString) 
                                || s.Group.Name.Contains(searchString))
                    .Include(g => g.Group)
                    .ToListAsync();
        }
    }
}
