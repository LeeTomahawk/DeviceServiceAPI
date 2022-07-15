using Domain.Entities;
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
        Task<Client> Add(Client client);
        void Update(Client client);
        System.Threading.Tasks.Task Delete(Client client);
    }
}
