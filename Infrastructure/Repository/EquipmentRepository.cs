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
    internal class EquipmentRepository : IEquipmentRepository
    {
        protected readonly DSMDbContext _dbcontext;
        protected readonly IMapper _mapper;

        public EquipmentRepository(DSMDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public async Task<Equipment> Add(Equipment equipment)
        {
            await _dbcontext.Set<Equipment>().AddAsync(equipment);
            await _dbcontext.SaveChangesAsync();
            return equipment;
        }

        public async void Delete(Equipment equipment)
        {
            _dbcontext.Remove(equipment);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Equipment> GetEquipmentById(Guid id)
        {
            var equipment = await _dbcontext.Set<Equipment>().FindAsync(id);
            if(equipment == null)
            {
                throw new Exception("Equipment does not exist");
            }
            return equipment;
        }

        public async Task<IEnumerable<Equipment>> GetEquipments()
        {
            var equipments = await _dbcontext.Set<Equipment>().ToListAsync();
            return equipments;
        }

        public async void Update(Equipment equipment)
        {
            var exequipment = await _dbcontext.Set<Equipment>().FindAsync(equipment.Id);
            if (equipment == null)
            {
                throw new Exception("Equipment does not exist");
            }
            _mapper.Map(equipment, exequipment);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
