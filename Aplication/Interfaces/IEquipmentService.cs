using Repositories.Dtos;

namespace Aplication.Interfaces
{
    public interface IEquipmentService
    {
        Task<PageResult<EquipmentDto>> GetEquipments(PageableModel query);
        Task<EquipmentDto> GetEquipmentById(Guid id);
        Task<EquipmentCreateDto> AddEquipment(EquipmentCreateDto equipment);
        Task UpdateEquipment(EquipmentUpdateDto equipment);
        Task DeleteEquipment(Guid id);
    }
}
