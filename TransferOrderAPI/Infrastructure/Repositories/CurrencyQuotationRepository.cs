using Core.Entities;
using Core.Interfaces;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class CurrencyQuotationRepository : BaseRepository, ICurrencyQuotationRepository
    {
        private CurrencyQuotationContext _context { get; set; }
        public CurrencyQuotationRepository(CurrencyQuotationContext context) : base(context)
        {
            _context = (CurrencyQuotationContext)context;
        }

        public bool SaveQuotations(dynamic quotations)
        {
            using (var context = _context)
            {
                var quotation = new CurrencyQuotation
                {
                    Id = 6,
                    source = "USD",
                    destination = "ARS",
                    rate = 1.0M,
                    timestamp = 123456789
                };
                context.CurrencyQuotations.Add(quotation);
                context.SaveChanges();
            }
            return true;
        }

    }
}
