﻿using Repositories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IWorkplaceService
    {
        Task<IEnumerable<WorkplaceDto>> GetWorkplaces();
        Task<WorkplaceDto> GetWorkPlaceById(Guid id);
        Task<WorkplaceCreateDto> AddWorkplace(WorkplaceCreateDto workplaceDto);
        Task DeleteWorkplace(Guid id);
        Task UpdateWorkplace(WorkplaceUpdateDto workplaceDto);
        Task AddWorkplaceEquipment(Guid workplaceId, Guid equipmentId);
        Task DeleteWorkplaceEquipment(Guid id);
        Task AddEmployee(Guid workplaceId, Guid employeeId);
    }
}
