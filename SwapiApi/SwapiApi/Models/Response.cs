using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwapiApi.Models
{
    public class Response
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public object Previous { get; set; }
        public List<Personaje> Results { get; set; }
    }
}
