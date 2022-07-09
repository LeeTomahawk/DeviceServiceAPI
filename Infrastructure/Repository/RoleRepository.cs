using AutoMapper;
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
        protected readonly IMapper _mapper;
        public RoleRepository(DSMDbContext dSMDbContext, IMapper mapper)
        {
            _dbcontext = dSMDbContext;
            _mapper = mapper;
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
            if (role == null)
            {
                throw new Exception("Role does not exist");
            }
            return role;
        }

        public async void Update(Role role)
        {
            var exrole = await _dbcontext.Set<Role>().FindAsync(role.Id);
            if(exrole == null)
            {
                throw new Exception("Role does not exist");
            }
            _mapper.Map(role, exrole);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
