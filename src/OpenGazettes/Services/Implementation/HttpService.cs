using HttpTracer;
using OpenGazettes.Services.Interfaces;
using Refit;
using System;
using System.Net.Http;

namespace OpenGazettes.Services.Implementation
{
    public class HttpService : IHttpService
    {
        public HttpService()
        {
            Client = new HttpClient(new HttpTracerHandler(new HttpDebugLogger()));

            Client.DefaultRequestHeaders.Add("Accept", "application/json");
            Client.BaseAddress = new Uri(Constants.UrlConstants.BaseUri);
        }

        public HttpClient Client { get; }
    }
}