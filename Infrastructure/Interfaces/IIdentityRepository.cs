using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IIdentityRepository
    {
        Task<IEnumerable<Identiti>> GetIdentitis();
        Task<Identiti> GetIdentitiById(Guid id);
        Task<Identiti> Add(Identiti identiti);
        void Update(Identiti identiti);
        void Delete(Identiti identiti);
    }
}
