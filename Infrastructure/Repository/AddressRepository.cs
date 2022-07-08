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
    public class AddressRepository : IAddressRepository
    {
        protected readonly DSMDbContext _dbcontext;
        public AddressRepository(DSMDbContext dSMDbContext)
        {
            _dbcontext = dSMDbContext;
        }
        public async Task<Address> Add(Address address)
        {
            await _dbcontext.Set<Address>().AddAsync(address);
            await _dbcontext.SaveChangesAsync();
            return address;
        }

        public async void Delete(Address address)
        {
            _dbcontext.Remove(address);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Address> GetAddressById(Guid id)
        {
            var address = await _dbcontext.Set<Address>().FindAsync(id);
            return address;
        }

        public async Task<IEnumerable<Address>> GetAddresses()
        {
            var addresses = await _dbcontext.Set<Address>().ToListAsync();
            return addresses;
        }

        public void Update(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
