using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ICurrencyQuotationService
    {
        void guardarCotizaciones(IEnumerable<dynamic> quotes);
    }
}
