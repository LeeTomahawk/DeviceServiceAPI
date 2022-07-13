using Aplication.Dtos;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _repository;
        private readonly IMapper _mapper;
        public EquipmentService(IEquipmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EquipmentCreateDto> AddEquipment(EquipmentCreateDto equipment)
        {
            var eq = _mapper.Map<Equipment>(equipment);
            var eqq = await _repository.Add(eq);
            return equipment;
        }

        public async Task<EquipmentDto> GetEquipmentById(Guid id)
        {
            var equipment = await _repository.GetEquipmentById(id);
            var equipmentdto = _mapper.Map<EquipmentDto>(equipment);
            return equipmentdto;
        }

        public async Task<IEnumerable<EquipmentDto>> GetEquipments()
        {
            var equipments = await _repository.GetEquipments();
            var equipmentsDto = _mapper.Map<IEnumerable<EquipmentDto>>(equipments);
            return equipmentsDto;
        }
    }
}
