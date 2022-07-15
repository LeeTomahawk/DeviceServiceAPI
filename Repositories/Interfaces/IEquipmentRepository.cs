using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetEquipments();
        Task<Equipment> GetEquipmentById(Guid id);
        Task<Equipment> Add(Equipment equipment);
        System.Threading.Tasks.Task Update(Equipment equipment);
        System.Threading.Tasks.Task Delete(Equipment equipment);
    }
}
