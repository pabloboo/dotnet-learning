using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalicianWeatherForecast.Models
{
    public class PredDiaConcello
    {
        public Ceo ceo { get; set; }
        public string dataPredicion { get; set; }
        public Pchoiva pchoiva { get; set; }
        public int tMax { get; set; }
        public int tMin { get; set; }
        public object nivelAviso { get; set; }
        public object tmaxFranxa { get; set; }
        public object tminFranxa { get; set; }
        public int uvMax { get; set; }
        public Vento vento { get; set; }
    }
}