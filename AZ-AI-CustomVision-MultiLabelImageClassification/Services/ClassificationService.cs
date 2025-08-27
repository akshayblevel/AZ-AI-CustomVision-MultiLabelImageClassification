using AZ_AI_CustomVision_MultiLabelImageClassification.Interfaces;
using System.Net.Http.Headers;

namespace AZ_AI_CustomVision_MultiLabelImageClassification.Services
{
    public class ClassificationService : IClassificationService
    {
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;
        private readonly string _apiVersion;
        private readonly string _projectId;
        private readonly string _publishedName;

        public ClassificationService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _endpoint = config["AzureVision:Endpoint"] ?? throw new ArgumentNullException("Endpoint");
            _apiVersion = config["AzureVision:ApiVersion"] ?? "";
            _projectId = config["AzureVision:ProjectId"] ?? "";
            _publishedName = config["AzureVision:PublishedName"] ?? "";

            _httpClient.DefaultRequestHeaders.Add("Prediction-Key", config["AzureVision:Key"]);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string?> ClassifyImageAsync(string imageUrl)
        {
            var uri = $"{_endpoint}customvision/{_apiVersion}/Prediction/{_projectId}/classify/iterations/{_publishedName}/url";
       
            HttpResponseMessage response;

            string requestBody = "{\"url\":\"" + imageUrl + "\"}";
            using (StringContent content = new StringContent(requestBody))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await _httpClient.PostAsync(uri, content);
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
