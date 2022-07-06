using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IWorkplaceRepository
    {
        IEnumerable<Workplace> GetWorkplaces();
        Workplace GetWorkplaceById(Guid id);
        Workplace Add(Workplace workplace);
        void Update(Workplace workplace);
        void Delete(Workplace workplace);
    }
}
