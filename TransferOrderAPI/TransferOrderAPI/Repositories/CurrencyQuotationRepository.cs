using API.Entities;
using API.Interfaces;
using API.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Repositories
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
            //TODO Quitar Hardcodeos ya se comprobo funcionamiento background service.
            //TODO pasar el parametro correcto
            //TODO Utilizar automapper
            using (var context = _context)
            {
                var quotation = new CurrencyQuotation
                {
                    Id = 6,
                    source = "USD",
                    destination = "ARS",
                    rate = 99.235597M,
                    timestamp = 123456789
                };
                context.CurrencyQuotations.Add(quotation);
                var quotation2 = new CurrencyQuotation
                {
                    Id = 7,
                    source = "ARS",
                    destination = "USD",
                    rate = 0.010077M,
                    timestamp = 123456789
                };
                context.CurrencyQuotations.Add(quotation2);
                context.Database.ExecuteSqlRaw("DROP TABLE IF EXISTS 'CurrencyQuotations'");
                context.Database.ExecuteSqlRaw("CREATE TABLE IF NOT EXISTS 'CurrencyQuotations' ('Id' INT NOT NULL PRIMARY KEY, 'source' TEXT , 'destination' TEXT, 'rate' DECIMAL(18,6), 'timestamp' int)");
                context.SaveChanges();
            }
            return true;
        }

    }
}
