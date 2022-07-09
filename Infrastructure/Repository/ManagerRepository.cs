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
            await _dbcontext.Set<Manager>().AddAsync(manager);
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
            var manager = await _dbcontext.Set<Manager>().FindAsync(id);
            if(manager == null)
            {
                throw new Exception("Manager does not exist");
            }
            return manager;
        }

        public async Task<IEnumerable<Manager>> GetManagers()
        {
            var managers = await _dbcontext.Set<Manager>().ToListAsync();
            return managers;
        }

        public async void Update(Manager manager)
        {
            var exmanager = await _dbcontext.Set<Manager>().FindAsync(manager.Id);
            if(exmanager == null)
            {
                throw new Exception("Manager does not exist");
            }
            _mapper.Map(manager, exmanager);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
