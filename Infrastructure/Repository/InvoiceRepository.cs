using AutoMapper;
using Domain;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        protected readonly DSMDbContext _dbcontext;
        protected readonly IMapper _mapper;

        public InvoiceRepository(DSMDbContext dbcontext, IMapper mapper)
        {
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public async Task<Invoice> Add(Invoice invoice)
        {
            await _dbcontext.Set<Invoice>().AddAsync(invoice);
            await _dbcontext.SaveChangesAsync();
            return invoice;
        }

        public async void Delete(Invoice invoice)
        {
            _dbcontext.Remove(invoice);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Invoice> GetInvoiceById(Guid id)
        {
            var invoice = await _dbcontext.Set<Invoice>().FindAsync(id);
            if(invoice == null)
            {
                throw new Exception("Invoice does not exist");
            }
            return invoice;
        }

        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            var invoices = await _dbcontext.Set<Invoice>().ToListAsync();
            return invoices;
        }

        public async void Update(Invoice invoice)
        {
            var exinvoice = await _dbcontext.Set<Invoice>().FindAsync(invoice.Id);
            if(exinvoice == null)
            {
                throw new Exception("Invoice does not exist");
            }
            _mapper.Map(invoice, exinvoice);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
