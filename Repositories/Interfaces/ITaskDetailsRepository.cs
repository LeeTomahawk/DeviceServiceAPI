using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Repositories.Interfaces
{
    public interface ITaskDetailsRepository
    {
        Task<IEnumerable<TaskDetails>> GetTaskDetails();
        Task<TaskDetails> GetTaskDetails(Guid id);
        Task<TaskDetails> Add(TaskDetails taskDetails);
        void Update(TaskDetails taskDetails);
        void Delete(TaskDetails taskDetails);
    }
}
