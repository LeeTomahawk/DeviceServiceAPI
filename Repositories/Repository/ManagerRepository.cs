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
using Repositories.Dtos;
using System.Linq.Expressions;

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

        public async Task<PageResult<ManagerDto>> GetManagers(PageableModel query)
        {
            var baseQuery = _dbcontext
                .Managers
                .Include(x => x.Identiti.Address)
                                .Where(r => query.SearchPharse == null || (r.Identiti.FirstName.ToLower().Contains(query.SearchPharse)
                                                     || r.Identiti.LastName.ToLower().Contains(query.SearchPharse)
                                                     || r.Identiti.PhoneNumber.ToLower().Contains(query.SearchPharse)));
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<Manager, object>>>
                {
                    {nameof(Manager.Identiti.FirstName), r => r.Identiti.FirstName },
                    {nameof(Manager.Identiti.LastName), r => r.Identiti.LastName },
                    {nameof(Manager.Identiti.PhoneNumber), r => r.Identiti.PhoneNumber },
                };

                var selectedColumn = columnsSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC ?
                    baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var managers = await baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToListAsync();

            var managersdto = _mapper.Map<IEnumerable<ManagerDto>>(managers);

            var result = new PageResult<ManagerDto>(managersdto, baseQuery.Count());

            return result;
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
