using AutoMapper;
using Domain;
using Domain.Entities;
using Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Exceptions;

namespace Repositories.Repository
{
    public class IdentitiRepository : IIdentityRepository
    {
        protected readonly DSMDbContext _dbcontext;
        protected readonly IMapper _mapper;
        public IdentitiRepository(DSMDbContext dSMDbContext, IMapper mapper)
        {
            _dbcontext = dSMDbContext;
            _mapper = mapper;
        }
        public async Task<Identiti> Add(Identiti identiti)
        {
            await _dbcontext.Identities.AddAsync(identiti);
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
            var identiti = await _dbcontext.Identities.FindAsync(id);
            if (identiti == null)
            {
                throw new NotFoundException("Identiti does not exist");
            }
            return identiti;
        }

        public async Task<IEnumerable<Identiti>> GetIdentitis()
        {
            var identities = await _dbcontext.Identities.ToListAsync();
            return identities;
        }

        public async void Update(Identiti identiti)
        {
            var exidentiti = await _dbcontext.Identities.FindAsync(identiti.Id);
            if(exidentiti == null)
            {
                throw new NotFoundException("Identiti does not exist");
            }
            _mapper.Map(identiti, exidentiti);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
