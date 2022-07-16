using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Dtos
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public DateTime? LastVisit { get; set; }
        public IdentitiDto Identiti { get; set; }
    }
}
