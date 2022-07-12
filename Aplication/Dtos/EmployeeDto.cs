using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public DateTime EmploymentDate { get; set; }
        public IEnumerable<CompletedTaskDto> CompletedTasks { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string PostCode { get; set; }
    }
}
