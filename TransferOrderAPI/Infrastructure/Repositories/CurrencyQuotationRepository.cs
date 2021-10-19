using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class CurrencyQuotationRepository : BaseRepository
    {
        public CurrencyQuotationRepository(DbContext context) : base(context)
        {
        }
    }
}
