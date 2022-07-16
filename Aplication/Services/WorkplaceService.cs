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
    public class WorkplaceService : IWorkplaceService
    {
        private readonly IWorkplaceRepository _repository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IMapper _mapper;
        public WorkplaceService(IWorkplaceRepository repository, IMapper mapper, IEquipmentRepository equipmentRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _equipmentRepository = equipmentRepository;
        }

        public async Task<WorkplaceCreateDto> AddWorkplace(WorkplaceCreateDto workplaceDto)
        {
            var workplace = _mapper.Map<Workplace>(workplaceDto);
            await _repository.Add(workplace);
            return workplaceDto;

        }

        public async System.Threading.Tasks.Task AddWorkplaceEquipment(WorkplaceEquipmentCreateDto workplaceEquipmentCreateDto)
        {
            var workplace = await _repository.GetWorkplaceById(workplaceEquipmentCreateDto.WokrplaceId);
            var equipment = await _equipmentRepository.GetEquipmentById(workplaceEquipmentCreateDto.EquipmentId);
            if(workplace == null || equipment == null)
            {
                throw new Exception("Workplace or equipment does not exist");
            }
            await _repository.AddEquipment(workplace, equipment);
        }

        public async System.Threading.Tasks.Task DeleteWorkplace(Guid id)
        {
            var workplace = await _repository.GetWorkplaceById(id);
            if(workplace == null)
            {
                throw new Exception("Workplace does not exist");
            }
            await _repository.Delete(workplace);
        }

        public async Task<WorkplaceDto> GetWorkPlaceById(Guid id)
        {
            var workplace = await _repository.GetWorkplaceById(id);
            var workplacedto = _mapper.Map<WorkplaceDto>(workplace);
            return workplacedto;
        }

        public async Task<IEnumerable<WorkplaceDto>> GetWorkplaces()
        {
            var workplaces = await _repository.GetWorkplaces();
            var worokplacesdto = _mapper.Map<IEnumerable<WorkplaceDto>>(workplaces);
            return worokplacesdto;
        }

        public async System.Threading.Tasks.Task UpdateWorkplace(WorkplaceUpdateDto workplaceDto)
        {
            await _repository.Update(workplaceDto);
        }
    }
}
