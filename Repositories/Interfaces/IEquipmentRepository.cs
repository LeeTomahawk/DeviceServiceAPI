using Domain.Entities;
using Repositories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IEquipmentRepository
    {
        Task<PageResult<EquipmentDto>> GetEquipments(PageableModel query);
        Task<Equipment> GetEquipmentById(Guid id);
        Task<Equipment> Add(Equipment equipment);
        System.Threading.Tasks.Task Update(EquipmentUpdateDto equipment);
        System.Threading.Tasks.Task Delete(Equipment equipment);
    }
}
