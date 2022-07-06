using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClients();
        Client GetClientById(Guid id);
        Client Add(Client client);
        void Update(Client client);
        void Delete(Client client);
    }
}
