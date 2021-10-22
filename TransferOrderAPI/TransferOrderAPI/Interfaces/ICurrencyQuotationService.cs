using System;
using System.Collections.Generic;
using System.Text;

namespace API.Interfaces
{
    public interface ICurrencyQuotationService
    {
        void guardarCotizaciones(IEnumerable<dynamic> quotes);
        decimal calcularCotizacionNeta(string sourceCurrency, string destinationCurrency, decimal netAmmount);
        decimal calcularCotizacionBruta(string sourceCurrency, string destinationCurrency, decimal grossAmmount);
    }
}
