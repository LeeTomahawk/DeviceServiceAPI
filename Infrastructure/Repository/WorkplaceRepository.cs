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
    public class WorkplaceRepository : IWorkplaceRepository
    {
        protected readonly DSMDbContext _dbcontext;
        protected readonly IMapper _mapper;

        public WorkplaceRepository(DSMDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public async Task<Workplace> Add(Workplace workplace)
        {
            await _dbcontext.Set<Workplace>().AddAsync(workplace);
            await _dbcontext.SaveChangesAsync();
            return workplace;
        }

        public async void Delete(Workplace workplace)
        {
            _dbcontext.Remove(workplace);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Workplace> GetWorkplaceById(Guid id)
        {
            var workplace = await _dbcontext.Set<Workplace>().FindAsync(id);
            if(workplace == null)
            {
                throw new Exception("Workplace does not exist");
            }
            return workplace;
        }

        public async Task<IEnumerable<Workplace>> GetWorkplaces()
        {
            var workplaces = await _dbcontext.Set<Workplace>().ToListAsync();
            return workplaces;
        }

        public async void Update(Workplace workplace)
        {
            var exworkplace = await _dbcontext.Set<Workplace>().FindAsync(workplace.Id);
            if(exworkplace == null)
            {
                throw new Exception("Workplace does not exist");
            }
            _mapper.Map(workplace, exworkplace);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
