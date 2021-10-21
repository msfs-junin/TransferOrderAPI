using API.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace API.Services
{
    public class CurrencyQuotationService : ICurrencyQuotationService, IScopedProcessingService
    {
        private readonly ILogger<CurrencyQuotationService> _logger;
        private readonly ICurrencyQuotationRepository _currencyQuotationRepository;
        private readonly IFeeRepository _feeRepository;

        public CurrencyQuotationService(
                                            ILogger<CurrencyQuotationService> logger,
                                            ICurrencyQuotationRepository currencyQuotationRepository
                                         )
        {
            _logger = logger;
            _currencyQuotationRepository = currencyQuotationRepository;
        }

        public Task DoWork(CancellationToken stoppingToken, dynamic quotes)
        {
            if (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Scoped Processing Service is working");
                _currencyQuotationRepository.SaveQuotations(quotes);
            }
            return Task.CompletedTask;
        }

        public void guardarCotizaciones(IEnumerable<dynamic> quotations)
        {
            _currencyQuotationRepository.SaveQuotations(quotations);
        }

        public decimal calcularCotizacionNeta(string sourceCurrency, string destinationCurrency, decimal netAmmount)
        {
            //Buscar las cotizaciones actuales.
            //buscar fee.
            //Quiero que lleguen 10000 pesos argentinos
            //Cuantos dolares tengo que depositar ?
            decimal cotizacion = _currencyQuotationRepository.getQuotation(sourceCurrency, destinationCurrency);
            decimal feePercent = 10.0M;//_feeRepository.getFeeForOperation(sourceCurrency, destinationCurrency);
            decimal fee = netAmmount * (feePercent / 100.0M);
            return (netAmmount + fee) * cotizacion;
        }
    }
}
