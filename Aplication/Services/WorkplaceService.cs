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
using Repositories.Exceptions;

namespace Aplication.Services
{
    public class WorkplaceService : IWorkplaceService
    {
        private readonly IWorkplaceRepository _repository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public WorkplaceService(IWorkplaceRepository repository, IMapper mapper, IEquipmentRepository equipmentRepository, IEmployeeRepository employeeRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _equipmentRepository = equipmentRepository;
            _employeeRepository = employeeRepository;
        }

        public async System.Threading.Tasks.Task AddEmployee(Guid workplaceId, Guid employeeId)
        {
            var workplace = await _repository.GetWorkplaceById(workplaceId);
            if (workplace == null)
                throw new NotFoundException("Workplace not found!");
            await _repository.AddEmployee(workplaceId, employeeId);
        }

        public async Task<WorkplaceCreateDto> AddWorkplace(WorkplaceCreateDto workplaceDto)
        {
            var workplace = _mapper.Map<Workplace>(workplaceDto);
            await _repository.Add(workplace);
            return workplaceDto;

        }

        public async System.Threading.Tasks.Task AddWorkplaceEquipment(Guid workplaceId, Guid equipmentId)
        {
            var workplace = await _repository.GetWorkplaceById(workplaceId);
            var equipment = await _equipmentRepository.GetEquipmentById(equipmentId);
            await _repository.AddEquipment(workplace, equipment);
        }

        public async System.Threading.Tasks.Task DeleteWorkplace(Guid id)
        {
            var workplace = await _repository.GetWorkplaceById(id);
            await _repository.Delete(workplace);
        }

        public async System.Threading.Tasks.Task DeleteWorkplaceEquipment(Guid id)
        {
            await _repository.DeleteEquipment(id);
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
