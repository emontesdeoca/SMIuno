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
        [AllowAnonymous]
        public string Ubicacion(string latitud, string longitud, int id)
        {
            ModeloCoordenadasUno coordenadaUno = new ModeloCoordenadasUno();
            ModeloCoordenadasDos coordenadaDos = new ModeloCoordenadasDos();
            ModeloCoordenadasTres coordenadaTres = new ModeloCoordenadasTres();

            if (id == 1)
            {
                coordenadaUno.id = id;
                coordenadaUno.latitudUno = latitud;
                coordenadaUno.longitudUno = longitud;
                coordenadaUno.fecha = DateTime.Now;
                db.ModeloCoordenadaUno.Add(coordenadaUno);
                db.SaveChanges();

                return "1";
            }
            if (id == 2)
            {
                coordenadaDos.id = id;
                coordenadaDos.latitudDos = latitud;
                coordenadaDos.longitudDos = longitud;
                coordenadaDos.fecha = DateTime.Now;
                db.ModeloCoordenadaDos.Add(coordenadaDos);
                db.SaveChanges();

                return "2";
            }
            if (id == 3)
            {
                coordenadaTres.id = id;
                coordenadaTres.latitudTres = latitud;
                coordenadaTres.longitudTres = longitud;
                coordenadaTres.fecha = DateTime.Now;
                db.ModeloCoordenadaTres.Add(coordenadaTres);
                db.SaveChanges();

                return "3";
            }
            return "0k";

        }

        public ActionResult EmergencyRoom()
        {
            var locationUno = (from m in db.ModeloCoordenadaUno orderby m.id descending select m).FirstOrDefault();
            ViewBag.LatitudUno = locationUno.latitudUno;
            ViewBag.LongitudUno = locationUno.longitudUno;

            var locationDos = (from n in db.ModeloCoordenadaDos orderby n.id descending select n).FirstOrDefault();
            ViewBag.LatitudDos = locationDos.latitudDos;
            ViewBag.LongitudDos = locationDos.longitudDos;

            var locationTres = (from o in db.ModeloCoordenadaTres orderby o.id descending select o).FirstOrDefault();
            ViewBag.LatitudTres = locationTres.latitudTres;
            ViewBag.LongitudTres = locationTres.longitudTres;
            if (!db.RootObjects)
            {
                Response.AddHeader("Refresh", "1");
            }
            //Response.AddHeader("Refresh", "10");
            return View(db.RootObjects.ToList());
        }

        public JsonResult GetAmbulances() 
        {
            
            
            var result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            var data = new
            {

                Coordenada1 = db.ModeloCoordenadaUno.ToArray().Last(),
                Coordenada2 = db.ModeloCoordenadaDos.ToArray().Last(),
                Coordenada3 = db.ModeloCoordenadaTres.ToArray().Last()
            };
            result.Data = data;
            return result;
        }

    }
}
