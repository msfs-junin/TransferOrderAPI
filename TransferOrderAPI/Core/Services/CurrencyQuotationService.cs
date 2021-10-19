using Core.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CurrencyQuotationService : ICurrencyQuotationService, IScopedProcessingService
    {
        private readonly ILogger<CurrencyQuotationService> _logger;
        private readonly ICurrencyQuotationRepository _currencyQuotationRepository;

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

    }
}
