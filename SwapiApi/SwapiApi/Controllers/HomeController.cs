using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwapiApi.Models;

namespace SwapiApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> About()
        {

            //BOOLEANO QUE MIRA SI HAY MAS PAGINAS EN LA API
            bool next = true;
            //OBJETO RESPUESTA (DEPENDERA DE COMO ESTA ORGANIZADA LA API)
            Response items = null;
            //INICIALIZAMOS EL CLIENTE HTTP
            HttpClient client = new HttpClient();
            //VARIABLE ITERADORA QUE RECORRERA LAS PAGINAS DE LA API
            int i = 1;
            //INICIAMOS LA LISTA DE PERSONAJES QUE LUEGO PASAREMOS A LA LISTA
            List<Personaje> personajes = new List<Personaje>();
            //MIENTRAS HAYA PAGINAS SEGUIRA EN EL BUCLE
            while (next)
            {
                //LA VARIABLE RESPONSE GUARDARA LA LLAMADA A LA API
                HttpResponseMessage response = await client.GetAsync("https://swapi.co/api/people/?page=" + i);
                //SI RECIBIMOS UNA RESPUESTA
                if (response.IsSuccessStatusCode)
                {
                    //GUARDAREMOS EN EL OBJETO(MODELO RESPONSE) EL CONTENIDO DE LA RESPUESTA
                    items = await response.Content.ReadAsAsync<Response>();
                    //SI EL ATRIBUTO NEXT(MIRA LA URL DE LA SIGUIENTE PAGINA) ES NULL, SALDREMOS DEL BUCLE PORQUE NO HAY MAS PERSONAJES
                    if (items.Next == null)
                    {
                        //PONEMOS NEXT A FALSO PARA QUE SALGA DEL BUCLE
                        next = false;
                    }
                }
                //RECORREMOS EL ARRAY RESULTS QUE ES EL QUE CONTIENE TODOS LOS DATOS QUE NECESITAMOS
                foreach (var item in items.Results)
                {
                    //CREAMOS UN PERSONAJE POR CADA ELEMENTO EN EL ARRAY RESULTS Y CREAMOS UN PERSONAJE
                    Personaje p = new Personaje
                    {
                        Name = item.Name,
                        Heigth = item.Heigth,
                        Mass = item.Mass,
                        Hair_color = item.Hair_color,
                        Skin_color = item.Skin_color,
                        Eye_color = item.Eye_color,
                        Birth_year = item.Birth_year,
                        Gender = item.Gender,
                        Homeworld = item.Homeworld
                    };

                    //ANADIMOS EL PERSONAJE CREADO A LA LISTA DE PERSONAJES
                    personajes.Add(p);
                }
                //ANADIMOS UNO A i PARA PASAR A LA SIGUIENTE PAGINA
                i++;
            }
            //PASAMOS POR PARAMETRO LA LISTA DE PERSONAJES A LA VISTA
            return View(personajes);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
