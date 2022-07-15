using Aplication.Dtos;
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
        Task DeleteClient(Guid id);
        Task UpdateClient(ClientDto cleintdto);
    }
}
