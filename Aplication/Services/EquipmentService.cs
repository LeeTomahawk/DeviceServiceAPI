using Repositories.Dtos;
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
        private readonly IWorkplaceRepository _workplaceRepository;
        private readonly IMapper _mapper;
        public EquipmentService(IEquipmentRepository repository, IMapper mapper, IWorkplaceRepository workplaceRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _workplaceRepository = workplaceRepository;
        }

        public async Task<EquipmentCreateDto> AddEquipment(EquipmentCreateDto equipment)
        {
            var eq = _mapper.Map<Equipment>(equipment);
            var eqq = await _repository.Add(eq);
            return equipment;
        }

        public async System.Threading.Tasks.Task DeleteEquipment(Guid id)
        {
            var equipment = await _repository.GetEquipmentById(id);
            if(equipment == null)
            {
                throw new Exception("Not found");
            }
            await _repository.Delete(equipment);
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

        public async Task<IEnumerable<EquipmentDto>> GetEquipmentToWorkplace(Guid workplaceId)
        {
            var workplace = await _workplaceRepository.GetWorkplaceById(workplaceId);
            var equipments = await _repository.GetEquipments();
            var availableEquipment = new List<EquipmentDto>();
            if(workplace.Equipments.Count() == 0)
            {
                return _mapper.Map<IEnumerable<EquipmentDto>>(equipments);
            }
            foreach (var weq in workplace.Equipments)
            {
                foreach(var eq in equipments)
                {
                    if(weq.EquipmentId != eq.Id)
                    {
                        var mapedEq = _mapper.Map<EquipmentDto>(eq);
                        availableEquipment.Add(mapedEq);
                    }
                }
            }
            return availableEquipment;
        }

        public async System.Threading.Tasks.Task UpdateEquipment(EquipmentUpdateDto equipment)
        {
            await _repository.Update(equipment);
        }
    }
}
