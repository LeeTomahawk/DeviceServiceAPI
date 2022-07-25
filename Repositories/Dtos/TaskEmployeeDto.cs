using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Dtos
{
    public class TaskEmployeeDto
    {
        public Guid TaskEmployeeId { get; set; }
        public Guid TaskId { get; set; }
    }
}
