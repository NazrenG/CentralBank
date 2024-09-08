using CentralBank.Entities.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralBank.Business.Concretes
{

    public class FetchCurrencyService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider; 
        public FetchCurrencyService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;  
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var currencyService = scope.ServiceProvider.GetRequiredService<CurrencyService>();
                    var centralBankDbContext = scope.ServiceProvider.GetRequiredService<CentralBankDbContext>();

                    var xmlData = await currencyService.GetXmlDataFromUrl();

                    if (!string.IsNullOrEmpty(xmlData))
                    {
                        var root = currencyService.ParseXmlData(xmlData);
                        await currencyService.StoreCurrencyData(root);
                    }
                    centralBankDbContext.Histories.Add(new Entities.Models.History { Created = DateTime.Now });
                    await centralBankDbContext.SaveChangesAsync();
                }
            
                // Wait 15 minutes
                await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken);
            }
        }
    }

}
