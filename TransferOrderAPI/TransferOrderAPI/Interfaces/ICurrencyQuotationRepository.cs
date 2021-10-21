using System;
using System.Collections.Generic;
using System.Text;

namespace API.Interfaces
{
    public interface ICurrencyQuotationRepository
    {
        bool SaveQuotations(dynamic quotes);
    }
}
