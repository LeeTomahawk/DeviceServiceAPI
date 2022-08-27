using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Dtos
{
    public class PageResult<T>
    {
        public int TotalResult { get; set; }
        public IEnumerable<T> Result { get; set; }

        public PageResult(IEnumerable<T> result, int totalResult)
        {
            Result = result;
            TotalResult = totalResult;
        }
    }
}
