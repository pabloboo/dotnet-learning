using GalicianWeatherForecast.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace GalicianWeatherForecast.Controllers
{
    public class ObservationController : Controller
    {
        // GET: Observation
        public ActionResult Index()
        {
            return View();
        }

        // GET: Observation/Camaras
        [Route("Observation/Camaras")]
        public ActionResult Camaras(string searchTerm = null)
        {
            var url = "https://servizos.meteogalicia.gal/mgrss/observacion/jsonCamaras.action?request_locale=gl";
            var client = new HttpClient();
            var listaDeCamaras = new ListaDeCamaras();

            try
            {
                var endpoint = new Uri(url);
                var repsonse = client.GetAsync(endpoint).Result;
                var json = repsonse.Content.ReadAsStringAsync().Result;
                listaDeCamaras = JsonConvert.DeserializeObject<ListaDeCamaras>(json);

                // Filter by concello
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    listaDeCamaras.ListaCamaras = listaDeCamaras.ListaCamaras
                        .Where(c => c.Concello.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();
                }
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }

            return View(listaDeCamaras);
        }
    }
}