using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Manager>> GetManagers();
        Task<Manager> GetManagerById(Guid id);
        Task<Manager> GetManagerByUserId(Guid userId);
        Task<Manager> Add(Manager manager);
        void Update(Manager manager);
        void Delete(Manager manager);
    }
}
