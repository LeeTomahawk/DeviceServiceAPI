using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddresses();
        Address GetAddressById(Guid id);
        Address Add(Address address);
        void Update(Address address);
        void Delete(Address address);
    }
}
