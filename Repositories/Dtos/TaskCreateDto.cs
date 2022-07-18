using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Dtos
{
    public class TaskCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime startDate { get; set; }
        public TaskStatus TaskStatus { get; set; }
    }
}
