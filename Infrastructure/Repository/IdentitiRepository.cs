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
    public class IdentitiRepository : IIdentityRepository
    {
        protected readonly DSMDbContext _dbcontext;
        public IdentitiRepository(DSMDbContext dSMDbContext)
        {
            _dbcontext = dSMDbContext;
        }
        public async Task<Identiti> Add(Identiti identiti)
        {
            await _dbcontext.Set<Identiti>().AddAsync(identiti);
            await _dbcontext.SaveChangesAsync();
            return identiti;
        }

        public async void Delete(Identiti identiti)
        {
            _dbcontext.Remove(identiti);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Identiti> GetIdentitiById(Guid id)
        {
            var identiti = await _dbcontext.Set<Identiti>().FindAsync(id);
            return identiti;
        }

        public async Task<IEnumerable<Identiti>> GetIdentitis()
        {
            var identities = await _dbcontext.Set<Identiti>().ToListAsync();
            return identities;
        }

        public void Update(Identiti identiti)
        {
            throw new NotImplementedException();
        }
    }
}
