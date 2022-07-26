using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Dtos
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public DateTime EmploymentDate { get; set; }

        public IdentitiDto Identiti { get; set; }
        public int TaskCount { get; set; }
        public IEnumerable<TaskEmployeeDto> Tasks { get; set; }
    }
}
