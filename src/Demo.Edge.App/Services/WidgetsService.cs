using Demo.Edge.App.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Demo.Edge.App.Services
{
    public interface IWidgetsService
    {
        Task<IEnumerable<WidgetViewModel>> GetAsync();
    }

    public class WidgetsService : IWidgetsService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<WidgetsService> _logger;
        private readonly MicroServicesConfig _urls;

        public WidgetsService(HttpClient httpClient, ILogger<WidgetsService> logger, IOptions<MicroServicesConfig> config)
        {
            _httpClient = httpClient;
            _logger = logger;
            _urls = config.Value;
        }

        public async Task<IEnumerable<WidgetViewModel>> GetAsync()
        {
            var url = _urls.Widgets + MicroServicesConfig.WidgetOperations.GetItems();

            _logger.LogInformation($"Calling {url}");

            var data = await _httpClient.GetStringAsync(url);
            var model = JsonConvert.DeserializeObject<IEnumerable<WidgetViewModel>>(data);

            return model;
        }
    }
}
