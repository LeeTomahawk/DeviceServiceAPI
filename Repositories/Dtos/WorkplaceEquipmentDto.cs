using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Dtos
{
    public class WorkplaceEquipmentDto
    {
        public Guid WokrplaceEquipmentId { get; set; }
        public Guid EquipmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
    }
    public class WorkplaceEquipmentCreateDto
    {
        public Guid WokrplaceId { get; set; }
        public Guid EquipmentId { get; set; }
    }
}
