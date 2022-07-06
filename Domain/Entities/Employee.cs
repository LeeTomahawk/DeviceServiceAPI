using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee : AuditableEntity
    {
        public Guid Id { get; set; }
        public virtual Identiti Identiti { get; set; }
        public Guid IdentitiId { get; set; }
        public virtual Workplace Workplace { get; set; }
        public Guid WorkplaceId { get; set; }
        public DateTime EmploymentDate { get; set; }
        public virtual ICollection<Task> Tasks { get; set; } = new HashSet<Task>();
    }
}
