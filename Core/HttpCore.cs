using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace BrasilSincero.Core
{
    public class HttpCore: HttpClient
    {
        private readonly IConfigurationRoot _configuration;
        public HttpCore(IConfigurationRoot configuration)
        {
            _configuration = configuration;
            BaseAddress = new Uri(_configuration.GetSection("DadosGoverno:UrlDownloadZip").Value);
        }

    }
}