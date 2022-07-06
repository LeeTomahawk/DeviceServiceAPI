using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : AuditableEntity
    {
        public Guid Id { get;set; }
        public virtual Role Role  { get;set; }
        public Guid RoleId { get;set; }
        public virtual Identiti Identiti { get;set; }
        public Guid IdentitiId { get;set; }
        string Email { get;set; }
        string Password { get;set; }

    }
}
