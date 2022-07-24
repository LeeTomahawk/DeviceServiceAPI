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
using Repositories.Dtos;
using Repositories.Exceptions;

namespace Repositories.Repository
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
            await _dbcontext.Workplaces.AddAsync(workplace);
            await _dbcontext.SaveChangesAsync();
            return workplace;
        }

        public async System.Threading.Tasks.Task AddEquipment(Workplace workplace, Equipment equipment)
        {
            var wq = new WorkplaceEquipment
            {
                WorkplaceId = workplace.Id,
                EquipmentId = equipment.Id
            };
            if(equipment.Amount == 0)
            {
                throw new BadRequestException("Amount of this item is 0");
            }
            equipment.Amount -= 1;
            await _dbcontext.WorkplaceEquipments.AddAsync(wq);
            await _dbcontext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(Workplace workplace)
        {
            _dbcontext.Remove(workplace);
            await _dbcontext.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task DeleteEquipment(Guid id)
        {
            var eq = await _dbcontext.WorkplaceEquipments.FindAsync(id);
            if (eq == null)
            {
                throw new NotFoundException("WorkpalceEquipment does not found");
            }
            var equipment = await _dbcontext.Equipments.FindAsync(eq.EquipmentId);
            _dbcontext.Remove(eq);
            equipment.Amount += 1;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Workplace> GetWorkplaceById(Guid id)
        {
            var workplace = await _dbcontext.Workplaces.Include(w => w.Equipments).ThenInclude(i => i.Equipment).FirstOrDefaultAsync(x => x.Id == id);
            if(workplace == null)
            {
                throw new NotFoundException("Workplace does not exist");
            }
            return workplace;
        }

        public async Task<IEnumerable<Workplace>> GetWorkplaces()
        {
            var workplaces = await _dbcontext.Workplaces.Include(w => w.Equipments).ThenInclude(i => i.Equipment).ToListAsync();
            return workplaces;
        }

        public async System.Threading.Tasks.Task Update(WorkplaceUpdateDto workplace)
        {
            var exworkplace = await _dbcontext.Workplaces.FindAsync(workplace.Id);
            if(exworkplace == null)
            {
                throw new NotFoundException("Workplace does not exist");
            }
            _mapper.Map(workplace, exworkplace);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
