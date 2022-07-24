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
            {
                throw new NotFoundException("Client not found");
            }
            return client;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            var clients = await _dbcontext.Clients.Include(s => s.Identiti).ThenInclude(i => i.Address).ToListAsync();
            return clients;
        }

        public async System.Threading.Tasks.Task Update(ClientUpdateDto client)
        {
            var exclient = await _dbcontext.Clients.FindAsync(client.Id);
            if(exclient == null)
            {
                throw new NotFoundException("Cleint not found");
            }
            _mapper.Map<ClientUpdateDto, Client>(client, exclient);
            _mapper.Map<IdentitiDto, Identiti>(client.Identiti, exclient.Identiti);
            _mapper.Map<AddressDto, Address>(client.Identiti.Address, exclient.Identiti.Address);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
