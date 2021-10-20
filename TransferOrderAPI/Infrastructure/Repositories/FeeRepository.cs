using Core.Interfaces;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class FeeRepository : BaseRepository, IFeeRepository
    {
        private FeeContext _context { get; set; }
        public FeeRepository(DbContext context) : base(context)
        {
            _context = (FeeContext)context;
        }

        public decimal getFeeForOperation(string sourceCurrency, string destinationCurrency)
        {
            throw new NotImplementedException();
        }
    }
}
