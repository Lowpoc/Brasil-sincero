using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using BrasilSincero.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace BrasilSincero.Core
{
    public class ProcessCore
    {
        private readonly HttpCore _httpCore;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;
        public ProcessCore(HttpCore httpCore, IConfiguration configuration, IHostingEnvironment environment)
        {
            _httpCore = httpCore;
            _configuration = configuration;
            _environment = environment;
        }
        public async Task BaixarDados(FiltroDados filtroDados)
        {
            var response = await _httpCore.GetAsync(
                string.Format("downloads.asp?a={0}&m={1}&consulta={2}",
             filtroDados.Ano, filtroDados.Mes, filtroDados.SaquePagamento));

             if(response.IsSuccessStatusCode){
                 using(var streamLer = await response.Content.ReadAsStreamAsync()){
                     var escreverArquivo = _environment.ContentRootPath + @"\" 
                     + response.Content.Headers.ContentDisposition.FileName;
                     using(var streamEscrever = File.Open(escreverArquivo, FileMode.Create)){
                         await streamEscrever.CopyToAsync(streamLer);
                     }
                 }
             }
        }
    }
}