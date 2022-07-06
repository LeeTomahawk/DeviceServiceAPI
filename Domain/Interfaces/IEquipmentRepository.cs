using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> GetEquipments();
        Equipment GetEquipmentById(Guid id);
        Equipment Add(Equipment equipment);
        void Update(Equipment equipment);
        void Delete(Equipment equipment);
    }
}
