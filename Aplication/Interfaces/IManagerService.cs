using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces
{
    public interface IManagerService
    {
        Task AddTaskToEmployee(Guid taskId, Guid employeeId);
    }
}
