using API.Interfaces;
using API.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Repositories
{
    public class FeeRepository : IFeeRepository, IDisposable
    {
        private readonly FeeContext _context; 
        
        public FeeRepository(FeeContext context) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public decimal getFeeForOperation(string sourceCurrency, string destinationCurrency)
        {
            //TODO Completar, añadir timestamps y definiri bien la clasee Fee vs CurrencyQuotation
            decimal rate = 0.0M;
            //TODO Reparar base.
            //var fee = _context.Fees
            //                .Where(f => f.source == sourceCurrency && f.destination == destinationCurrency)
            //                .FirstOrDefault().rate;
            rate = 10.0M;// fee;
            return rate;
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
