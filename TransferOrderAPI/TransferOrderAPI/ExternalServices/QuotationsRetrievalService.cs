using API.Entities;
using API.Interfaces;
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
    //public class QuotationsRetrievalService : BackgroundService
    public class QuotationsRetrievalService : IHostedService
    {
        private readonly ILogger<QuotationsRetrievalService> _logger;
        private readonly string _quotationApiKey = null;
        private Timer _timer;

        public QuotationsRetrievalService(IServiceProvider services,
            ILogger<QuotationsRetrievalService> logger)
        {
            Services = services;
            _logger = logger;
            //TODO Inyectar
            _quotationApiKey = "1124f8b1c4eee98fee0c86571cfd487c";
        }

        public IServiceProvider Services { get; }

        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    _logger.LogInformation("El servicio esta corriendo.");
        //    await DoWork(stoppingToken);
        //}

        //private async Task DoWork(CancellationToken stoppingToken)
        //{
        //    _logger.LogInformation("Busco cotizacion.");
        //    HttpClient http = new HttpClient();
        //    //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ACCESS_KEY", "1124f8b1c4eee98fee0c86571cfd487c");
        //    string url = "http://api.currencylayer.com/live?access_key=" + _quotationApiKey;
        //    var apiResponse = http.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        //    if (apiResponse != "")
        //    {
        //        var datos = JsonConvert.DeserializeObject<APIResponse>(apiResponse);
        //        using (var scope = Services.CreateScope())
        //        {
        //            var scopedProcessingService =
        //                scope.ServiceProvider
        //                    .GetRequiredService<IScopedProcessingService>();
        //            await scopedProcessingService.DoWork(stoppingToken, datos.quotes);
        //        }
        //    }
        //}

        //public override async Task StopAsync(CancellationToken stoppingToken)
        //{
        //    _logger.LogInformation(
        //        "El servicio se está deteniendo.");

        //    await base.StopAsync(stoppingToken);
        //}

        private async Task DoWork(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Busco cotizacion.");
            HttpClient http = new HttpClient();
            //http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("ACCESS_KEY", "1124f8b1c4eee98fee0c86571cfd487c");
            string url = "http://api.currencylayer.com/live?access_key=" + _quotationApiKey;
            //var apiResponse = http.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            var apiResponse = "{\"success\":true,\"terms\":\"https:\\/\\/currencylayer.com\\/terms\",\"privacy\":\"https:\\/\\/currencylayer.com\\/privacy\",\"timestamp\":1634803804,\"source\":\"USD\",\"quotes\":{\"USDAED\":3.673198,\"USDAFN\":89.495131,\"USDALL\":104.342977,\"USDAMD\":476.663535,\"USDANG\":1.798685,\"USDAOA\":597.065956,\"USDARS\":99.327457,\"USDAUD\":1.336362,\"USDAWG\":1.8,\"USDAZN\":1.698457,\"USDBAM\":1.677866,\"USDBBD\":2.015193,\"USDBDT\":85.407214,\"USDBGN\":1.67866,\"USDBHD\":0.376937,\"USDBIF\":1984.962019,\"USDBMD\":1,\"USDBND\":1.341237,\"USDBOB\":6.881539,\"USDBRL\":5.597803,\"USDBSD\":0.998048,\"USDBTC\":1.5322569e-5,\"USDBTN\":74.704568,\"USDBWP\":11.120071,\"USDBYN\":2.435733,\"USDBYR\":19600,\"USDBZD\":2.011762,\"USDCAD\":1.23406,\"USDCDF\":2011.999976,\"USDCHF\":0.92057,\"USDCLF\":0.029502,\"USDCLP\":814.050551,\"USDCNY\":6.399498,\"USDCOP\":3768.09,\"USDCRC\":627.125841,\"USDCUC\":1,\"USDCUP\":26.5,\"USDCVE\":94.594073,\"USDCZK\":22.004031,\"USDDJF\":177.67388,\"USDDKK\":6.39485,\"USDDOP\":56.156951,\"USDDZD\":137.207274,\"USDEGP\":15.702799,\"USDERN\":15.001239,\"USDETB\":47.145633,\"USDEUR\":0.859455,\"USDFJD\":2.066601,\"USDFKP\":0.733222,\"USDGBP\":0.724535,\"USDGEL\":3.1299,\"USDGGP\":0.733222,\"USDGHS\":6.060627,\"USDGIP\":0.733222,\"USDGMD\":52.049748,\"USDGNF\":9665.165358,\"USDGTQ\":7.722373,\"USDGYD\":208.912586,\"USDHKD\":7.77545,\"USDHNL\":24.060976,\"USDHRK\":6.4529,\"USDHTG\":99.300429,\"USDHUF\":312.833986,\"USDIDR\":14141.3,\"USDILS\":3.21119,\"USDIMP\":0.733222,\"USDINR\":74.845203,\"USDIQD\":1457.158912,\"USDIRR\":42250.000008,\"USDISK\":128.930137,\"USDJEP\":0.733222,\"USDJMD\":150.720386,\"USDJOD\":0.709027,\"USDJPY\":114.061964,\"USDKES\":111.049637,\"USDKGS\":84.793099,\"USDKHR\":4063.857804,\"USDKMF\":422.900356,\"USDKPW\":899.9997,\"USDKRW\":1177.260338,\"USDKWD\":0.30157,\"USDKYD\":0.831728,\"USDKZT\":425.721382,\"USDLAK\":10113.28492,\"USDLBP\":1523.902631,\"USDLKR\":200.110411,\"USDLRD\":158.850179,\"USDLSL\":14.430177,\"USDLTL\":2.95274,\"USDLVL\":0.60489,\"USDLYD\":4.551011,\"USDMAD\":9.018363,\"USDMDL\":17.35271,\"USDMGA\":3951.170342,\"USDMKD\":52.85824,\"USDMMK\":1876.299826,\"USDMNT\":2850.924447,\"USDMOP\":7.993085,\"USDMRO\":356.999828,\"USDMUR\":43.401804,\"USDMVR\":15.459599,\"USDMWK\":814.32634,\"USDMXN\":20.27785,\"USDMYR\":4.158994,\"USDMZN\":63.830257,\"USDNAD\":14.501353,\"USDNGN\":410.201286,\"USDNIO\":35.136619,\"USDNOK\":8.34819,\"USDNPR\":119.522353,\"USDNZD\":1.394335,\"USDOMR\":0.384962,\"USDPAB\":0.998057,\"USDPEN\":3.941699,\"USDPGK\":3.505083,\"USDPHP\":50.815496,\"USDPKR\":173.183349,\"USDPLN\":3.949296,\"USDPYG\":6901.982988,\"USDQAR\":3.640987,\"USDRON\":4.252503,\"USDRSD\":100.852303,\"USDRUB\":71.006501,\"USDRWF\":1015.874786,\"USDSAR\":3.750467,\"USDSBD\":8.054836,\"USDSCR\":14.62394,\"USDSDG\":439.481055,\"USDSEK\":8.59682,\"USDSGD\":1.34548,\"USDSHP\":1.377403,\"USDSLL\":10599.999585,\"USDSOS\":585.999747,\"USDSRD\":21.428981,\"USDSTD\":20697.981008,\"USDSVC\":8.733362,\"USDSYP\":1256.972024,\"USDSZL\":14.472988,\"USDTHB\":33.420273,\"USDTJS\":11.265415,\"USDTMT\":3.505,\"USDTND\":2.813013,\"USDTOP\":2.23395,\"USDTRY\":9.261699,\"USDTTD\":6.776592,\"USDTWD\":27.880249,\"USDTZS\":2304.999745,\"USDUAH\":26.139738,\"USDUGX\":3598.920778,\"USDUSD\":1,\"USDUYU\":43.694372,\"USDUZS\":10661.073293,\"USDVEF\":213830222338.07285,\"USDVND\":22751,\"USDVUV\":112.296433,\"USDWST\":2.576993,\"USDXAF\":562.722348,\"USDXAG\":0.041394,\"USDXAU\":0.000561,\"USDXCD\":2.70255,\"USDXDR\":0.704822,\"USDXOF\":562.727175,\"USDXPF\":102.829725,\"USDYER\":250.25006,\"USDZAR\":14.49515,\"USDZMK\":9001.199053,\"USDZMW\":17.051761,\"USDZWL\":321.999592}}";

            if (apiResponse != "")
            {
                var datos = JsonConvert.DeserializeObject<APIResponse>(apiResponse);
                using (var scope = Services.CreateScope())
                {
                    var scopedProcessingService =
                        scope.ServiceProvider
                            .GetRequiredService<IScopedProcessingService>();
                    await scopedProcessingService.DoWork(stoppingToken, datos.quotes);
                }
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("El servicio esta corriendo.");
            _timer = new Timer(async (algo) => await DoWork(cancellationToken), cancellationToken, TimeSpan.Zero, TimeSpan.FromSeconds(1000));
            return Task.CompletedTask;
            //    await DoWork(stoppingToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
