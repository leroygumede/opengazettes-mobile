using HttpTracer;
using OpenGazettes.Services.Interfaces;
using Refit;
using System;
using System.Net.Http;

namespace OpenGazettes.Services.Implementation
{
    public class HttpService : IHttpService
    {
        //private readonly HttpClient _configuredHttpClient;
        //private readonly RefitSettings _refitSettings;

        //ICollectionService _collectionService;
        //IGazetteService _gazetteService;

        public HttpService()
        {
            Client = new HttpClient(new HttpTracerHandler(new HttpDebugLogger()));

            Client.DefaultRequestHeaders.Add("Accept", "application/json");
            Client.BaseAddress = new Uri(Constants.UrlConstants.BaseUri);
        }

        public HttpClient Client { get; }

        //public HttpService()
        //{
        //    _configuredHttpClient = new HttpClient(new HttpTracerHandler((HttpTracer.Logger.ILogger)new HttpDebugLogger()));
        //    _configuredHttpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        //    _configuredHttpClient.DefaultRequestHeaders.Add("Accept", "application/pdf");

        //    _refitSettings = new RefitSettings
        //    {
        //        ContentSerializer = new JsonContentSerializer(new JsonSerializerSettings
        //        {
        //            NullValueHandling = NullValueHandling.Ignore,
        //            DefaultValueHandling = DefaultValueHandling.Ignore
        //        })
        //    };
        //}

        //public ICollectionService CollectionServiceApi
        //{
        //    get
        //    {
        //        if (_collectionService == null)
        //        {
        //            _configuredHttpClient.BaseAddress = new Uri(Constants.Constants.BaseUri);
        //            _collectionService = RestService.For<ICollectionService>(_configuredHttpClient, _refitSettings);
        //        }

        //        return _collectionService;
        //    }
        //}

        //public IGazetteService GazetteServiceServiceApi
        //{
        //    get
        //    {
        //        if (_gazetteService == null)
        //        {
        //            _configuredHttpClient.BaseAddress = new Uri(Constants.Constants.BaseUriArchive);
        //            _gazetteService = RestService.For<IGazetteService>(_configuredHttpClient, _refitSettings);
        //        }

        //        return _gazetteService;
        //    }
        //}

        //async Task<HttpResponseMessage> IHttpService.GetAsync(string url)
        //{
        //    return await _configuredHttpClient.GetAsync(url);
        //}
    }
}