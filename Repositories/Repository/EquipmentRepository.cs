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
using System.Linq.Expressions;
namespace Repositories.Repository
{
    public class EquipmentRepository : IEquipmentRepository
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
            await _dbcontext.Equipments.AddAsync(equipment);
            await _dbcontext.SaveChangesAsync();
            return equipment;
        }

        public async System.Threading.Tasks.Task Delete(Equipment equipment)
        {
            _dbcontext.Remove(equipment);
            await _dbcontext.SaveChangesAsync();
        }



        public async Task<Equipment> GetEquipmentById(Guid id)
        {
            var equipment = await _dbcontext.Equipments.FindAsync(id);
            if(equipment == null)
            {
                throw new NotFoundException("Equipment does not exist");
            }
            return equipment;
        }

        public async Task<PageResult<EquipmentDto>> GetEquipments(PageableModel query)
        {
            var baseQuery = _dbcontext
                .Equipments
                .Where(r => query.SearchPharse == null || r.Name.ToLower().Contains(query.SearchPharse)
                                                       || r.Description.ToLower().Contains(query.SearchPharse));

            if(!string.IsNullOrEmpty(query.SortBy))
            {
                var columnSelectors = new Dictionary<string, Expression<Func<Equipment, object>>>
                {
                    {nameof(Equipment.Name), r => r.Name},
                    {nameof(Equipment.Description), r => r.Description},
                };

                var selectedColumn = columnSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC ?
                    baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var equipments = await baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToListAsync();

            var equipmentsDto = _mapper.Map<IEnumerable<EquipmentDto>>(equipments);

            var result = new PageResult<EquipmentDto>(equipmentsDto, baseQuery.Count());

            return result;
        }

        public async System.Threading.Tasks.Task Update(EquipmentUpdateDto equipment)
        {
            var exequipment = await _dbcontext.Equipments.FindAsync(equipment.Id);
            if (equipment == null)
            {
                throw new NotFoundException("Equipment does not exist");
            }
            _mapper.Map<EquipmentUpdateDto, Equipment>(equipment, exequipment);
            await _dbcontext.SaveChangesAsync();
        }

        
    }
}
