﻿using AutoMapper;
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
            await _dbcontext.Set<Client>().AddAsync(client);
            await _dbcontext.SaveChangesAsync();
            return client;
        }

        public async void Delete(Client client)
        {
            _dbcontext.Remove(client);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Client> GetClientById(Guid id)
        {
            var client = await _dbcontext.Set<Client>().FindAsync(id);
            if(client == null)
            {
                throw new Exception("Client does not exist");
            }
            return client;
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            var clients = await _dbcontext.Set<Client>().ToListAsync();
            return clients;
        }

        public async void Update(Client client)
        {
            var exclient = await _dbcontext.Set<Client>().FindAsync(client.Id);
            if(exclient == null)
            {
                throw new Exception("Client does not exist");
            }
            _mapper.Map(client, exclient);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
