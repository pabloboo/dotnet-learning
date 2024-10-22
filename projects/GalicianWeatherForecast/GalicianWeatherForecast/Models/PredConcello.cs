using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalicianWeatherForecast.Models
{
    public class PredConcello
    {
        public int idConcello { get; set; }
        public List<PredDiaConcello> listaPredDiaConcello { get; set; }
        public string nome { get; set; }
    }
}