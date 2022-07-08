using Domain;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RoleRepository : IRoleRepository
    {
        protected readonly DSMDbContext _dbcontext;
        public RoleRepository(DSMDbContext dSMDbContext)
        {
            _dbcontext = dSMDbContext;
        }
        public async Task<Role> Add(Role role)
        {
            await _dbcontext.Set<Role>().AddAsync(role);
            await _dbcontext.SaveChangesAsync();
            return role;
        }

        public async void Delete(Role role)
        {
            _dbcontext.Remove(role);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            var roles = await _dbcontext.Set<Role>().ToListAsync();
            return roles;
        }

        public async Task<Role> GetRoleById(Guid id)
        {
            var role = await _dbcontext.Set<Role>().FindAsync(id);
            return role;
        }

        public void Update(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
