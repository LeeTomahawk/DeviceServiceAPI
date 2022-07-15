using Aplication.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IClientService
    {
        Task<ClientCreateDto> AddClient(ClientCreateDto clientdto);
        Task<IEnumerable<ClientDto>> GetClients();
        Task<ClientDto> GetClient(Guid id);
        System.Threading.Tasks.Task DeleteClient(Guid id);
        System.Threading.Tasks.Task UpdateClient(ClientDto cleintdto);
    }
}
