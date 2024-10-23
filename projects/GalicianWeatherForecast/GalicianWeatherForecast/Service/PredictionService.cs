using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalicianWeatherForecast.Service
{
    public class PredictionService
    {
        public string GetSkyText(string skyId)
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
    }
}