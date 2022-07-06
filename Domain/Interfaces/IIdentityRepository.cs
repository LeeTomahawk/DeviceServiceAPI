using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IIdentityRepository
    {
        IEnumerable<Identiti> GetIdentitis();
        Identiti GetIdentitiById(Guid id);
        Identiti Add(Identiti identiti);
        void Update(Identiti identiti);
        void Delete(Identiti identiti);
    }
}
