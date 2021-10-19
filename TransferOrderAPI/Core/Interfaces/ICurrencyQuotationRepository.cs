using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ICurrencyQuotationRepository
    {
        bool saveQuotations(dynamic quotes);
    }
}
