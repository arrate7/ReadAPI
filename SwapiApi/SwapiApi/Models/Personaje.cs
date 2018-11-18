using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiApi.Models
{
    public class Personaje
    {
        public string Name { get; set; }
        public int Heigth { get; set; }
        public string Mass { get; set; }
        public string Hair_color { get; set; }
        public string Skin_color { get; set; }
        public string Eye_color { get; set; }
        public string Birth_year { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
    }
}
