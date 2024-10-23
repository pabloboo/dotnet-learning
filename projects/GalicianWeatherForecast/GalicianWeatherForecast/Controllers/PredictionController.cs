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
    public class PredictionController : Controller
    {

        // GET: Municipios
        [Route("Prediction/Municipios")]
        public ActionResult Municipios(string sortOrder)
        {
            var municipios = ObtainMunicipios();

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

        private string ObtainMunicipioId(string municipio)
        {
            var municipios = ObtainMunicipios();

            foreach (var municipioVar in municipios)
            {
                if (municipioVar.name == municipio)
                {
                    return municipioVar.id;
                }
            }

            return null;
        }

        private List<Municipio> ObtainMunicipios()
        {
            var municipios = new List<Municipio>();

            municipios.Add(new Municipio()
            {
                id = "15030",
                name = "A Coruña"
            });

            municipios.Add(new Municipio()
            {
                id = "15036",
                name = "Ferrol"
            });

            municipios.Add(new Municipio()
            {
                id = "27028",
                name = "Lugo"
            });

            municipios.Add(new Municipio()
            {
                id = "32054",
                name = "Ourense"
            });

            municipios.Add(new Municipio()
            {
                id = "36038",
                name = "Pontevedra"
            });

            municipios.Add(new Municipio()
            {
                id = "15078",
                name = "Santiago de Compostela"
            });

            municipios.Add(new Municipio()
            {
                id = "36057",
                name = "Vigo"
            });

            return municipios;

        }
    }
}