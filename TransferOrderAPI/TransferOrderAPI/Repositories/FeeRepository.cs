using API.Interfaces;
using API.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API.Repositories
{
    public class FeeRepository : BaseRepository, IFeeRepository
    {
        private FeeContext _context { get; set; }
        
        public FeeRepository(FeeContext context) : base(context)
        {
            _context = (FeeContext)context;
        }

        public decimal getFeeForOperation(string sourceCurrency, string destinationCurrency)
        {
            //TODO Completar, añadir timestamps y definiri bien la clasee Fee vs CurrencyQuotation
            decimal rate = 0.0M;
            using (var context = _context)
            {
                var fee = _context.Fees
                                .Where(f => f.source == sourceCurrency && f.destination == destinationCurrency)
                                .FirstOrDefault().rate;
                rate = fee;
            }
            return rate;
        }
    }
}
