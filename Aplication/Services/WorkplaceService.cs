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
    public class WorkplaceService : IWorkplaceService
    {
        private readonly IWorkplaceRepository _repository;
        private readonly IMapper _mapper;
        public WorkplaceService(IWorkplaceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WorkplaceCreateDto> AddWorkplace(WorkplaceCreateDto workplaceDto)
        {
            var workplace = _mapper.Map<Workplace>(workplaceDto);
            await _repository.Add(workplace);
            return workplaceDto;

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
    }
}
