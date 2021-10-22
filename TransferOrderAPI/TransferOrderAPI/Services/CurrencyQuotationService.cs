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
                                            ICurrencyQuotationRepository currencyQuotationRepository,
                                            IFeeRepository feeRepository
                                         )
        {
            _logger = logger;
            _currencyQuotationRepository = currencyQuotationRepository;
            _feeRepository = feeRepository;
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

        private decimal obtenerCotizacion(string sourceCurrency, string destinationCurrency)
        {
            return _currencyQuotationRepository.getQuotation(sourceCurrency, destinationCurrency);
        }

        public decimal calcularCotizacionNeta(string sourceCurrency, string destinationCurrency, decimal netAmmount)
        {
            decimal cotizacion = obtenerCotizacion(sourceCurrency, destinationCurrency);
            decimal feePercent = _feeRepository.getFeeForOperation(sourceCurrency, destinationCurrency);
            decimal fee = netAmmount * (feePercent / 100.0M);
            return (netAmmount + fee) * cotizacion;
        }

        public decimal calcularCotizacionBruta(string sourceCurrency, string destinationCurrency, decimal grossAmmount)
        {
            decimal cotizacion = obtenerCotizacion(sourceCurrency, destinationCurrency);
            
            decimal feePercent = _feeRepository.getFeeForOperation(sourceCurrency, destinationCurrency); //_feeRepository.getFeeForOperation(sourceCurrency, destinationCurrency);
            decimal fee = grossAmmount * (feePercent / 100.0M);

            return (grossAmmount - fee) * cotizacion;
        }
    }
}
