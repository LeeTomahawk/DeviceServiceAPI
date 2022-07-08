using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAddresses();
        Task<Address> GetAddressById(Guid id);
        Task<Address> Add(Address address);
        void Update(Address address);
        void Delete(Address address);
    }
}
