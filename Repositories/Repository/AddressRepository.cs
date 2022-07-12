using AutoMapper;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class AddressRepository : IAddressRepository
    {
        protected readonly DSMDbContext _dbcontext;
        protected readonly IMapper _mapper;
        public AddressRepository(DSMDbContext dSMDbContext, IMapper mapper)
        {
            _dbcontext = dSMDbContext;
            _mapper = mapper;
        }
        public async Task<Address> Add(Address address)
        {
            await _dbcontext.Addresses.AddAsync(address);
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
            var address = await _dbcontext.Addresses.FindAsync(id);
            if (address == null)
            {
                throw new Exception("Addres does not exist!");
            }
            return address;
        }

        public async Task<IEnumerable<Address>> GetAddresses()
        {
            var addresses = await _dbcontext.Addresses.ToListAsync();
            return addresses;
        }

        public async void Update(Address address)
        {
            var exaddress = await _dbcontext.Addresses.FindAsync(address.Id);
            if( exaddress == null)
            {
                throw new Exception("Addres does not exist!");
            }
            _mapper.Map(address, exaddress);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
