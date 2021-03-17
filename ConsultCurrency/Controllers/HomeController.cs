using ConsultCurrency.Data;
using ConsultCurrency.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nager.Date;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsultCurrency.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public ContextDb db = new ContextDb(null);

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Periodo()
        {
            return View();
        }

        public async Task<IActionResult> GetValueDay(Contexto json)
        {
            try
            {
                string url = null;
                string data = null;             

                string tipoMoeda = json.idMoeda == 0 ? "'USD'" : "'EUR'";

                if (string.IsNullOrEmpty(json.data))
                {
                     data = VerificaDiaUtil(DateTime.Now);                   
                }
                else
                {
                    DateTime verificaData = Convert.ToDateTime(json.data);
                     data = VerificaDiaUtil(verificaData);
                }

                url = "https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoMoedaDia(moeda=@moeda,dataCotacao=@dataCotacao)?@moeda={0}&@dataCotacao='{1}'&$format=json";

                url = string.Format(url, tipoMoeda,data);

                return Ok(ConsomeApi(url, tipoMoeda));
            }
            catch (Exception e)
            {

                throw;
            }
        }
        private async Task<IActionResult> ConsomeApi(string url, string tipoMoeda)
        {
            try
            {
                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                //retorna todos os valores porém estou salvando somente a cotacaoCompra, somente pra exemplificar
                string retorno = await response.Content.ReadAsStringAsync();

                Valor valor = JsonConvert.DeserializeObject<Valor>(retorno);

                Contexto contexto = valor.value.FirstOrDefault();
               
                Cambio cambio = new Cambio
                {
                    VL_CAMBIO = contexto.cotacaoCompra,
                   MoedaID_MOEDA = tipoMoeda == "USD" ? 1 : 2,
                };

                db.Cambio.Add(cambio);
                db.SaveChanges();

                return Json(JsonConvert.SerializeObject(valor));
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Verifica se a data informada é dia útil.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string VerificaDiaUtil(DateTime dateTime)
        {
            try
            {               
                while (true)
                {
                    if (dateTime.DayOfWeek == DayOfWeek.Saturday)
                        dateTime = dateTime.AddDays(-1);
                    else if (dateTime.DayOfWeek == DayOfWeek.Sunday)
                        dateTime = dateTime.AddDays(-2);                  

                    var publicHolidays = DateSystem.GetPublicHoliday(dateTime, dateTime, CountryCode.BR);

                    if (publicHolidays.Count() > 0)
                        dateTime = dateTime.AddDays(-1);
                    else
                        return dateTime.ToString("MM-dd-yyyy");
                }
            }
            catch (Exception E)
            {
                throw new Exception("Buscar próximo dia útil", E);
            }
        }
    }
}
