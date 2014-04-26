using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFinal.Models;

namespace ProyectoFinal.Controllers
{
    public class UploadPhotosController : Controller
    {
        private PatientModelDBContext db = new PatientModelDBContext();

        //
        // GET: /UploadPhotos/

        public ActionResult Index()
        {
            var uploadimagen = db.UploadImagen.Include(i => i.PatientModel);
            return View(uploadimagen.ToList());
        }

        //
        // GET: /UploadPhotos/Details/5

        public ActionResult Details(int id = 0)
        {
            Image image = db.UploadImagen.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        //
        // GET: /UploadPhotos/Create

        public ActionResult Create()
        {
            ViewBag.PatientModelId = new SelectList(db.Patients, "Id", "Nombre");
            return View();
        }

        //
        // POST: /UploadPhotos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Image imagen, HttpPostedFileBase file, int id = 0)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Images/") + file.FileName);
                    imagen.ImagePath = file.FileName;
                }
                imagen.CreadoPor = User.Identity.Name;
                imagen.PatientModelId = id;
                db.UploadImagen.Add(imagen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientModelId = new SelectList(db.Patients, "Id", "Nombre", imagen.PatientModelId);
            return View(imagen);
        }

        //
        // GET: /UploadPhotos/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Image image = db.UploadImagen.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientModelId = new SelectList(db.Patients, "Id", "Nombre", image.PatientModelId);
            return View(image);
        }

        //
        // POST: /UploadPhotos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientModelId = new SelectList(db.Patients, "Id", "Nombre", image.PatientModelId);
            return View(image);
        }

        //
        // GET: /UploadPhotos/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Image image = db.UploadImagen.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        //
        // POST: /UploadPhotos/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.UploadImagen.Find(id);
            db.UploadImagen.Remove(image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}