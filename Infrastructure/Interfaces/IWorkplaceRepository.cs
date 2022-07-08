using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IWorkplaceRepository
    {
        Task<IEnumerable<Workplace>> GetWorkplaces();
        Task<Workplace> GetWorkplaceById(Guid id);
        Task<Workplace> Add(Workplace workplace);
        void Update(Workplace workplace);
        void Delete(Workplace workplace);
    }
}
