using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IManagerReposotory
    {
        Task<IEnumerable<Manager>> GetManagers();
        Task<Manager> GetManagerById(Guid id);
        Task<Manager> Add(Manager manager);
        void Update(Manager manager);
        void Delete(Manager manager);
    }
}
