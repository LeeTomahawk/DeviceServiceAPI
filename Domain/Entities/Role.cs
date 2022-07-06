using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Role : AuditableEntity
    {
        public Guid Id { get; set; }
        public RoleType RoleType { get; set; }
    }
}
