using Domain.Entities;
using Repositories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IWorkplaceRepository
    {
        Task<IEnumerable<Workplace>> GetWorkplaces();
        Task<Workplace> GetWorkplaceById(Guid id);
        Task<Workplace> Add(Workplace workplace);
        System.Threading.Tasks.Task Update(WorkplaceUpdateDto workplace);
        System.Threading.Tasks.Task Delete(Workplace workplace);
        System.Threading.Tasks.Task AddEquipment(Workplace workplace, Equipment equipment);
        System.Threading.Tasks.Task DeleteEquipment(Guid id);
    }
}
