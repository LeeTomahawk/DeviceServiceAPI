using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetInvoices();
        Task<Invoice> GetInvoiceById(Guid id);
        Task<Invoice> Add(Invoice invoice);
        void Update(Invoice invoice);
        void Delete(Invoice invoice);
    }
}
