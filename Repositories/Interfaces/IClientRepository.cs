using Domain.Entities;
using Repositories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClientById(Guid id);
        Task<IEnumerable<Client>> GetClientByPhoneNumber(string phonenumber);
        Task<Client> Add(Client client);
        System.Threading.Tasks.Task Update(ClientUpdateDto client);
        System.Threading.Tasks.Task Delete(Client client);
    }
}
