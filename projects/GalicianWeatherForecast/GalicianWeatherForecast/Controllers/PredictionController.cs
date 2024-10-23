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

        // GET: Sky text
        [Route("Prediction/SkyText/{skyId}")]
        public string SkyText(string skyId)
        {
            if (skyId == null)
            {
                return "";
            }

            var skyText = GetSkyText(skyId);

            return skyText;
        }

        private string GetSkyText(string skyId)
        {
            switch (skyId)
            {
                case "101":
                    return "Despexado";
                case "102":
                    return "Nubes altas";
                case "103":
                    return "Nubes e claros";
                case "104":
                    return "Anubrado 75%";
                case "105":
                    return "Cuberto";
                case "106":
                    return "Néboas";
                case "107":
                    return "Chuvasco";
                case "108":
                    return "Chuvasco 75%";
                case "109":
                    return "Chuvasco neve";
                case "110":
                    return "Orballo";
                case "111":
                    return "Choiva";
                case "112":
                    return "Neve";
                case "113":
                    return "Treboada";
                case "114":
                    return "Brétema";
                case "115":
                    return "Bancos de néboa";
                case "116":
                    return "Nubes medias";
                case "117":
                    return "Choiva débil";
                case "118":
                    return "Chuvascos débiles";
                case "119":
                    return "Treboada con poucas nubes";
                case "120":
                    return "Auga neve";
                case "121":
                    return "Sarabia";

                // Night
                case "201":
                    return "Despexado";
                case "202":
                    return "Nubes altas";
                case "203":
                    return "Nubes e claros";
                case "204":
                    return "Anubrado 75%";
                case "205":
                    return "Cuberto";
                case "206":
                    return "Néboas";
                case "207":
                    return "Chuvasco";
                case "208":
                    return "Chuvasco 75%";
                case "209":
                    return "Chuvasco neve";
                case "210":
                    return "Orballo";
                case "211":
                    return "Choiva";
                case "212":
                    return "Neve";
                case "213":
                    return "Treboada";
                case "214":
                    return "Brétema";
                case "215":
                    return "Bancos de néboa";
                case "216":
                    return "Nubes medias";
                case "217":
                    return "Choiva débil";
                case "218":
                    return "Chuvascos débiles";
                case "219":
                    return "Treboada con poucas nubes";
                case "220":
                    return "Auga neve";
                case "221":
                    return "Sarabia";

                default:
                    return "Non dispoñible";
            }
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