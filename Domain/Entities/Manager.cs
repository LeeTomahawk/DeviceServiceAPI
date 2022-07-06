using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Manager : AuditableEntity
    {
        public Guid Id { get; set; }
        public virtual Identiti Identiti { get; set; }
        public Guid IdentitiId { get; set; }
        public DateTime EmploymentDate { get; set; }
    }
}
