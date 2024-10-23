using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GalicianWeatherForecast.Models
{
    public class Camara
    {
        public string Concello { get; set; }
        public string DataUltimaAct { get; set; }
        public int IdConcello { get; set; }
        public int Identificador { get; set; }
        public string ImaxeCamara { get; set; }
        public string ImaxeCamaraMini { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string NomeCamara { get; set; }
        public string Provincia { get; set; }
    }
}