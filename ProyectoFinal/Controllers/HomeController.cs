using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProyectoFinal.Models;
using Newtonsoft.Json;

namespace ProyectoFinal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private PatientModelDBContext db = new PatientModelDBContext();
        private RootObjectRepository repo = new RootObjectRepository();

        public ActionResult Index()
        {
            ViewBag.Message = "Sistema Medico Integrado";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //[HttpPost]
        [AllowAnonymous]
        public ActionResult Insert(string data)
        {
            try
            {
                var recibido = JsonConvert.DeserializeObject<RootObject>(data);
                repo.InsertOrUpdate(recibido);
                repo.Save();
            }
            catch (Exception err)
            {
                return new JsonResult { Data = err.ToString() };
            }
            return new JsonResult { Data = "Eureka" };
        }

        [HttpGet]
        public string Ubicacion(string latitud, string longitud, int id)
        {
            ModeloCoordenadas coordenada = new ModeloCoordenadas();

            coordenada.id = id;
            coordenada.latitud = latitud;
            coordenada.longitud = longitud;
            coordenada.fecha = DateTime.Now;
            db.ModeloCoordenada.Add(coordenada);
            db.SaveChanges();

            return "1";

        }

        public ActionResult EmergencyRoom()
        {
            var location = (from i in db.ModeloCoordenada orderby i.id descending select i).FirstOrDefault();
            ViewBag.Latitud = location.latitud;
            ViewBag.Longitud = location.longitud;
            //Response.AddHeader("Refresh", "10");
            return View(db.RootObjects.ToList());
        }

    }
}
