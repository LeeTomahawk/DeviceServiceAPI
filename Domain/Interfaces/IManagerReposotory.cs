using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IManagerReposotory
    {
        IEnumerable<Manager> GetManagers();
        Manager GetManagerById(Guid id);
        Manager Add(Manager manager);
        void Update(Manager manager);
        void Delete(Manager manager);
    }
}
