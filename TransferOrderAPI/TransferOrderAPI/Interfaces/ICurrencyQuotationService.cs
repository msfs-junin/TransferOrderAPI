using System;
using System.Collections.Generic;
using System.Text;

namespace API.Interfaces
{
    public interface ICurrencyQuotationService
    {
        void guardarCotizaciones(IEnumerable<dynamic> quotes);
    }
}
