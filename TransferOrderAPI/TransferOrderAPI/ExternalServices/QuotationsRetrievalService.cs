using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace API.ExternalServices
{
    public class QuotationsRetrievalService : BackgroundService
    {
        private readonly ILogger<QuotationsRetrievalService> _logger;
        private readonly string _quotationApiKey = null;

        public QuotationsRetrievalService(IServiceProvider services,
            ILogger<QuotationsRetrievalService> logger)
        {
            Services = services;
            _logger = logger;
            //TODO Inyectar
            _quotationApiKey = "1124f8b1c4eee98fee0c86571cfd487c";
        }

        public IServiceProvider Services { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("El servicio esta corriendo.");
            await DoWork(stoppingToken);
        }

        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Busco cotizacion.");
            HttpClient http = new HttpClient();
            //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ACCESS_KEY", "1124f8b1c4eee98fee0c86571cfd487c");
            string url = "http://api.currencylayer.com/live?access_key=" + _quotationApiKey;
            var apiResponse = http.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            if (apiResponse != "")
            {
               
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation(
                "El servicio se está deteniendo.");

            await base.StopAsync(stoppingToken);
        }
     

    }
}
