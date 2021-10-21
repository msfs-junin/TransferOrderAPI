using API.Entities;
using API.Interfaces;
using API.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Repositories
{
    public class CurrencyQuotationRepository : ICurrencyQuotationRepository, IDisposable
    {
        private readonly CurrencyQuotationContext _context;
        public CurrencyQuotationRepository(CurrencyQuotationContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool SaveQuotations(dynamic quotations)
        {
            //TODO Quitar Hardcodeos ya se comprobo funcionamiento background service.
            //TODO pasar el parametro correcto
            //TODO Utilizar automapper
            using (var context = _context)
            {
                foreach (var algo in quotations)
                {
                    var quotation = new CurrencyQuotation
                    {
                        //Id = new Guid(""),
                        source = algo.Key.Substring(0, 3),
                        destination = algo.Key.Substring(3, 3),
                        rate = algo.Value,
                        timestamp = 123456789
                    };
                    context.CurrencyQuotations.Add(quotation);
                }
               // context.CurrencyQuotations.Add(quotation2);
                //context.Database.ExecuteSqlRaw("DROP TABLE IF EXISTS 'CurrencyQuotations'");
                //context.Database.ExecuteSqlRaw("CREATE TABLE IF NOT EXISTS 'CurrencyQuotations' ('Id' INT NOT NULL PRIMARY KEY, 'source' TEXT , 'destination' TEXT, 'rate' DECIMAL(18,6), 'timestamp' int)");
                context.SaveChanges();
            }
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

    }
}
