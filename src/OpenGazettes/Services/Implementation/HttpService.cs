using HttpTracer;
using OpenGazettes.Services.Interfaces;
using Refit;
using System;
using System.Net.Http;
using System.Text.Json;

namespace OpenGazettes.Services.Implementation
{
    public class HttpService : IHttpService
    {
        public HttpService()
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };

            var settings = new RefitSettings()
            {
                ContentSerializer = new SystemTextJsonContentSerializer(options)
            };

            Client = new HttpClient(new HttpTracerHandler(new HttpDebugLogger())
                );

            Client.DefaultRequestHeaders.Add("Accept", "application/json");
            Client.BaseAddress = new Uri(Constants.UrlConstants.BaseUri);
        }

        public HttpClient Client { get; }
    }
}