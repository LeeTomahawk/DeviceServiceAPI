using AutoMapper;
using Domain;
using Domain.Entities;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Exceptions;

namespace Repositories.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        protected readonly DSMDbContext _dbcontext;
        protected readonly IMapper _mapper;

        public ManagerRepository(DSMDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public async Task<Manager> Add(Manager manager)
        {
            await _dbcontext.Managers.AddAsync(manager);
            await _dbcontext.SaveChangesAsync();
            return manager;
        }

        public async void Delete(Manager manager)
        {
            _dbcontext.Remove(manager);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Manager> GetManagerById(Guid id)
        {
            var manager = await _dbcontext.Managers.FindAsync(id);
            if(manager == null)
                throw new NotFoundException("Manager does not exist");
            return manager;
        }

        public async Task<Manager> GetManagerByUserId(Guid userId)
        {
            var user = await _dbcontext.Users.FindAsync(userId);
            var manager = await _dbcontext.Managers.Include(x => x.Identiti).FirstOrDefaultAsync(x => x.IdentitiId == user.IdentitiId);
            if(user == null || manager == null)
                throw new NotFoundException("Manager does not exist");
            return manager;
        }

        public async Task<IEnumerable<Manager>> GetManagers()
        {
            var managers = await _dbcontext.Managers.ToListAsync();
            return managers;
        }

        public async void Update(Manager manager)
        {
            var exmanager = await _dbcontext.Managers.FindAsync(manager.Id);
            if(exmanager == null)
                throw new NotFoundException("Manager does not exist");
            _mapper.Map(manager, exmanager);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
