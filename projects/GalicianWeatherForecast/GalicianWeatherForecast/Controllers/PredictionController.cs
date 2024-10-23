using GalicianWeatherForecast.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using GalicianWeatherForecast.Service;

namespace GalicianWeatherForecast.Controllers
{
    public class PredictionController : Controller
    {
        readonly MunicipioService municipioService = new MunicipioService();
        readonly PredictionService predictionService = new PredictionService();

        // GET: Municipios
        [Route("Prediction/Municipios")]
        public ActionResult Municipios(string sortOrder, string searchTerm)
        {
            var municipios = municipioService.ObtainMunicipios();

            switch(sortOrder)
            {
                case "asc":
                    municipios = municipios.OrderBy(m => m.name).ToList();
                    break;
                case "desc":
                    municipios = municipios.OrderByDescending(m => m.name).ToList();
                    break;
                default:
                    break;
            }

            if (searchTerm != null)
            {
                municipios = municipios
                    .Where(m => m.name.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }

            return View(municipios);
        }

        // GET: Prediction
        [Route("Prediction/Municipios/{municipioId}")]
        public ActionResult Prediction(string municipioId)
        {
            if (municipioId == null)
            {
                return HttpNotFound();
            }

            var url = $"https://servizos.meteogalicia.gal/mgrss/predicion/jsonPredConcellos.action?idConc={municipioId}&request_locale=gl";
            var client = new HttpClient();
            var prediction = new Prediction();

            try
            {
                var endpoint = new Uri(url);
                var response = client.GetAsync(endpoint).Result;
                var json = response.Content.ReadAsStringAsync().Result;
                prediction = JsonConvert.DeserializeObject<Prediction>(json);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }

            return View(prediction);
        }

        // GET: Sky text
        [Route("Prediction/SkyText/{skyId}")]
        public string SkyText(string skyId)
        {
            if (skyId == null)
            {
                return "";
            }

            var skyText = predictionService.GetSkyText(skyId);

            return skyText;
        }

    }
}