using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class WorkplaceEquipmentDto
    {
        public Guid Id { get; set; }
        public EquipmentDto Equipment { get; set; }
    }
}
