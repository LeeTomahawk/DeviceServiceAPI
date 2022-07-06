using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> GetInvoices();
        Invoice GetInvoiceById(Guid id);
        Invoice Add(Invoice invoice);
        void Update(Invoice invoice);
        void Delete(Invoice invoice);
    }
}
