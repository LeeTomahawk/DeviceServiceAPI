using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Workplace : AuditableEntity
    {
        
        public Guid Id { get; set; }
        public string Identifier { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; } = new HashSet<Equipment>();
    }
}
