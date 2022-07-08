using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAll();
        Task<Role> GetRoleById(Guid id);
        Task<Role> Add(Role role);
        void Update(Role role);
        void Delete(Role role);
    }
}
