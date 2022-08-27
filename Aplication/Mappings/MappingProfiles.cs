using Repositories.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Aplication.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<TaskEmployee, TaskEmployeeDto>()
                .ForMember(r => r.TaskEmployeeId, c => c.MapFrom(s => s.Id));
            CreateMap<Manager, ManagerDto>();
            CreateMap<User, UserDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Identiti, IdentitiDto>();
            CreateMap<AddressDto, Address>();
            CreateMap<IdentitiDto, Identiti>();
            CreateMap<ClientUpdateDto, Client>()
                .AfterMap((src, dest) =>
                {
                    dest.Identiti.FirstName = src.FirstName;
                    dest.Identiti.LastName = src.LastName;
                    dest.Identiti.PhoneNumber = src.PhoneNumber;
                    dest.Identiti.Address.City = src.City;
                    dest.Identiti.Address.Street = src.Street;
                    dest.Identiti.Address.Number = src.Number;
                    dest.Identiti.Address.PostCode = src.PostCode;
                });
            CreateMap<ClientDto, Client>();
            CreateMap<Client, ClientDto>();
            CreateMap<TaskCreateDto, Domain.Entities.Task>();
            CreateMap<TaskDto, Domain.Entities.Task>();
            CreateMap<TaskUpdateDto, Domain.Entities.Task>();
            CreateMap<Domain.Entities.Task, TaskDto>();
            CreateMap<Equipment, EquipmentDto>();
            CreateMap<EquipmentUpdateDto, Equipment>();
            CreateMap<EquipmentCreateDto, Equipment>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<WorkplaceUpdateDto, Workplace>();
            CreateMap<Workplace, WorkplaceDto>()
                .ForMember(r => r.EquipmentsDto, c => c.MapFrom(s => s.Equipments));
            CreateMap<WorkplaceEquipment, WorkplaceEquipmentDto>()
                .ForMember(r => r.WokrplaceEquipmentId, c => c.MapFrom(s => s.Id))
                .ForMember(r => r.EquipmentId, c => c.MapFrom(s => s.EquipmentId))
                .ForMember(r => r.Name, c => c.MapFrom(s => s.Equipment.Name))
                .ForMember(r => r.Description, c => c.MapFrom(s => s.Equipment.Description))
                .ForMember(r => r.Amount, c => c.MapFrom(s => s.Equipment.Amount));
            CreateMap<WorkplaceCreateDto, Workplace>();
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
            CreateMap<RegisterUserDto, User>()
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
