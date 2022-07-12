using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IEquipmentService
    {
        Task<IEnumerable<Equipment>> GetEquipments();
        Task<Equipment> GetEquipment(Guid id);
        Task<Equipment> AddEquipment(Equipment eq);
    }
}
