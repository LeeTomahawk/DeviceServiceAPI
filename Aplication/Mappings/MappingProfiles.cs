using Aplication.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<EquipmentCreateDto, Equipment>();
            CreateMap<Employee, EmployeeDto>()
                .ForMember(r => r.FirstName, c => c.MapFrom(s => s.Identiti.FirstName))
                .ForMember(r => r.LastName, c => c.MapFrom(s => s.Identiti.LastName))
                .ForMember(r => r.PhoneNumber, c => c.MapFrom(s => s.Identiti.PhoneNumber))
                .ForMember(r => r.City, c => c.MapFrom(s => s.Identiti.Address.City))
                .ForMember(r => r.Street, c => c.MapFrom(s => s.Identiti.Address.Street))
                .ForMember(r => r.Number, c => c.MapFrom(s => s.Identiti.Address.Number))
                .ForMember(r => r.PostCode, c => c.MapFrom(s => s.Identiti.Address.PostCode));
            CreateMap<Workplace, WorkplaceDto>()
                .ForMember(r => r.Equipments, c => c.MapFrom(s => s.Equipments));
            CreateMap<WorkplaceEquipment, WorkplaceEquipmentDto>();
        }
    }
}
