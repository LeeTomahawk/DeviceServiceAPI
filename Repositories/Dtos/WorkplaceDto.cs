using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Dtos
{
    public class WorkplaceDto
    {
        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public IEnumerable<WorkplaceEquipmentDto> EquipmentsDto { get; set; }
    }
}
