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
            CreateMap<Client, ClientDto>()
                .ForMember(r => r.FirstName, c => c.MapFrom(s => s.Identiti.FirstName))
                .ForMember(r => r.LastName, c => c.MapFrom(s => s.Identiti.LastName))
                .ForMember(r => r.PhoneNumber, c => c.MapFrom(s => s.Identiti.PhoneNumber))
                .ForMember(r => r.City, c => c.MapFrom(s => s.Identiti.Address.City))
                .ForMember(r => r.Street, c => c.MapFrom(s => s.Identiti.Address.Street))
                .ForMember(r => r.Number, c => c.MapFrom(s => s.Identiti.Address.Number))
                .ForMember(r => r.PostCode, c => c.MapFrom(s => s.Identiti.Address.PostCode));
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<EquipmentUpdateDto, Equipment>();
            CreateMap<EquipmentCreateDto, Equipment>();
            CreateMap<Equipment, Equipment>();
            CreateMap<Employee, EmployeeDto>()
                .ForMember(r => r.FirstName, c => c.MapFrom(s => s.Identiti.FirstName))
                .ForMember(r => r.LastName, c => c.MapFrom(s => s.Identiti.LastName))
                .ForMember(r => r.PhoneNumber, c => c.MapFrom(s => s.Identiti.PhoneNumber))
                .ForMember(r => r.City, c => c.MapFrom(s => s.Identiti.Address.City))
                .ForMember(r => r.Street, c => c.MapFrom(s => s.Identiti.Address.Street))
                .ForMember(r => r.Number, c => c.MapFrom(s => s.Identiti.Address.Number))
                .ForMember(r => r.PostCode, c => c.MapFrom(s => s.Identiti.Address.PostCode));
            CreateMap<Workplace, WorkplaceDto>()
                .ForMember(r => r.EquipmentsDto, c => c.MapFrom(s => s.Equipments));
            CreateMap<WorkplaceEquipment, WorkplaceEquipmentDto>()
                .ForMember(r => r.WokrplaceEquipmentId, c => c.MapFrom(s => s.Id))
                .ForMember(r => r.EquipmentId, c => c.MapFrom(s => s.EquipmentId))
                .ForMember(r => r.Name, c => c.MapFrom(s => s.Equipment.Name))
                .ForMember(r => r.Description, c => c.MapFrom(s => s.Equipment.Description))
                .ForMember(r => r.Amount, c => c.MapFrom(s => s.Equipment.Amount));
            CreateMap<WorkplaceCreateDto, Workplace>();
            CreateMap<Domain.Entities.Task, TaskDto>();
            CreateMap<TaskCreateDto, Domain.Entities.Task>();
            
            CreateMap<ClientCreateDto, Client>()
                .AfterMap((src, dest) =>
                {
                    dest.Identiti = new Identiti();
                    dest.Identiti.Address = new Address();

                    dest.Identiti.FirstName = src.FirstName;
                    dest.Identiti.LastName = src.LastName;
                    dest.Identiti.PhoneNumber = src.PhoneNumber;
                    dest.Identiti.Address.City = src.City;
                    dest.Identiti.Address.Street = src.Street;
                    dest.Identiti.Address.Number = src.Number;
                    dest.Identiti.Address.PostCode = src.PostCode;
                });
        }
    }
}
