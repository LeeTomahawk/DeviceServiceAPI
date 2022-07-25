using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Dtos
{
    public class TaskCreateDetailDto
    {
        public Guid EmployeeId { get; set; }
        public TaskDetailStatus TaskDetailStatus { get; set; }
    }
}
