using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetEquipments();
        Task<Equipment> GetEquipmentById(Guid id);
        Task<Equipment> Add(Equipment equipment);
        void Update(Equipment equipment);
        void Delete(Equipment equipment);
    }
}
