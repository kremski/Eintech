using Eintech.DAL;
using Eintech.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eintech.Service
{
    public interface IGroupService
    {
        Task<List<Group>> GetAllGroupsAsync();
    }

    public class GroupService : IGroupService
    {
        private readonly EintechDbContext _context;

        public GroupService(EintechDbContext context)
        {
            _context = context;
        }

        public async Task<List<Group>> GetAllGroupsAsync()
        {
            return await _context.Groups
                    .AsNoTracking()
                    .ToListAsync();
        }
    }
}
