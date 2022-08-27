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
    public class ClientRepository : IClientRepository
    {
        protected readonly DSMDbContext _dbcontext;
        protected readonly IMapper _mapper;

        public ClientRepository(DSMDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public async Task<Client> Add(Client client)
        {
            await _dbcontext.Clients.AddAsync(client);
            await _dbcontext.SaveChangesAsync();
            return client;
        }

        public async System.Threading.Tasks.Task Delete(Client client)
        {
            _dbcontext.Addresses.Remove(client.Identiti.Address);
            _dbcontext.Identities.Remove(client.Identiti);
            _dbcontext.Clients.Remove(client);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Client> GetClientById(Guid id)
        {
            var client = await _dbcontext.Clients.Include(s => s.Identiti).ThenInclude(i => i.Address).FirstOrDefaultAsync(x => x.Id == id);
            if(client == null)
                throw new NotFoundException("Client not found");
            return client;
        }

        public async Task<IEnumerable<Client>> GetClientByPhoneNumber(string phonenumber)
        {
            var client = await _dbcontext.Clients.Include(c => c.Identiti.Address).Where(x => x.Identiti.PhoneNumber.Contains(phonenumber)).ToListAsync();
            if (client == null)
                throw new NotFoundException("Client not found");
            return client;
        }

        public async Task<PageResult<ClientDto>> GetClients(PageableModel query)
        {
            var baseQuery = _dbcontext
                .Clients
                .Include(s => s.Identiti.Address)
                .Where(r => query.SearchPharse == null || (r.Identiti.FirstName.ToLower().Contains(query.SearchPharse)
                                                     || r.Identiti.LastName.ToLower().Contains(query.SearchPharse)
                                                     || r.Identiti.PhoneNumber.ToLower().Contains(query.SearchPharse)));
            if (!string.IsNullOrEmpty(query.SortBy))
            {
                var columnsSelectors = new Dictionary<string, Expression<Func<Client, object>>>
                {
                    {nameof(Client.Identiti.FirstName), r => r.Identiti.FirstName },
                    {nameof(Client.Identiti.LastName), r => r.Identiti.LastName },
                    {nameof(Client.Identiti.PhoneNumber), r => r.Identiti.PhoneNumber },
                };

                var selectedColumn = columnsSelectors[query.SortBy];

                baseQuery = query.SortDirection == SortDirection.ASC ? 
                    baseQuery.OrderBy(selectedColumn)
                    : baseQuery.OrderByDescending(selectedColumn);
            }

            var clients = await baseQuery
                .Skip(query.PageSize * (query.PageNumber - 1))
                .Take(query.PageSize)
                .ToListAsync();

            var clientsDto = _mapper.Map<IEnumerable<ClientDto>>(clients);

            var result = new PageResult<ClientDto>(clientsDto, baseQuery.Count());

            return result;
        }

        public async System.Threading.Tasks.Task Update(ClientUpdateDto client)
        {
            var exclient = await _dbcontext.Clients.Include(s => s.Identiti).ThenInclude(w => w.Address).FirstOrDefaultAsync(x => x.Id == client.Id);
            if(exclient == null)
                throw new NotFoundException("Client not found");
            _mapper.Map<ClientUpdateDto, Client>(client, exclient);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
