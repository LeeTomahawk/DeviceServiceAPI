using Aplication.Dtos;

namespace Aplication.Interfaces
{
    public interface IEquipmentService
    {
        Task<IEnumerable<EquipmentDto>> GetEquipments();
        Task<EquipmentDto> GetEquipmentById(Guid id);
        Task<EquipmentCreateDto> AddEquipment(EquipmentCreateDto equipment);
        Task UpdateEquipment(EquipmentUpdateDto equipment);
        Task DeleteEquipment(Guid id);
    }
}
