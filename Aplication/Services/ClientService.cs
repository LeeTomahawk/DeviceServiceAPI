using Repositories.Dtos;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;
        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ClientCreateDto> AddClient(ClientCreateDto clientdto)
        {
            var client = _mapper.Map<Client>(clientdto);
            await _repository.Add(client);
            return clientdto;
        }

        public async Task<IEnumerable<ClientDto>> GetClients()
        {
            var clients = await _repository.GetClients();
            var clientsdto = _mapper.Map<IEnumerable<ClientDto>>(clients);
            return clientsdto;
        }

        public async Task<ClientDto> GetClient(Guid id)
        {
            var client = await _repository.GetClientById(id);
            var clientdto = _mapper.Map<ClientDto>(client);
            return clientdto;
        }

        public async System.Threading.Tasks.Task DeleteClient(Guid id)
        {
            var client = await _repository.GetClientById(id);
            await _repository.Delete(client);
        }

        public async System.Threading.Tasks.Task UpdateClient(ClientUpdateDto clientdto)
        {
            await _repository.Update(clientdto);
        }

        public async Task<IEnumerable<ClientDto>> GetClientByPhoneNumber(string phonenumber)
        {
            var client = await _repository.GetClientByPhoneNumber(phonenumber);
            var clientdto = _mapper.Map<IEnumerable<ClientDto>>(client);
            return clientdto;
        }
    }
}
