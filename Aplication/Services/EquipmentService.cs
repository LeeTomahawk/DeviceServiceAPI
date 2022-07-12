using Aplication.Interfaces;
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
        protected readonly IEquipmentRepository _repository;
        //public EquipmentService(IEquipmentRepository repository)
        //{
        //    _repository = repository;
        //}

        public Task<Equipment> AddEquipment(Equipment eq)
        {
            throw new NotImplementedException();
        }

        public Task<Equipment> GetEquipment(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Equipment>> GetEquipments()
        {
            //var equipments = _repository.GetEquipments();
            //return equipments;
            return null;
        }
    }
}
