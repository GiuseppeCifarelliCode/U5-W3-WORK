using InForno.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InForno.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AggiunzioneController : Controller
    {
        private ModelDBContext db = new ModelDBContext();
        // GET: Aggiunzione
        public ActionResult Index()
        {
            return View(db.Aggiunzione);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Aggiunzione a)
        {
            if (ModelState.IsValid)
            {
                db.Aggiunzione.Add(a);      
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "Dati Non Validi";
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            return View(db.Aggiunzione.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Aggiunzione a)
        {
            if (ModelState.IsValid)
            {
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(a);
        }

        public ActionResult Delete(int id)
        {
            Aggiunzione a = db.Aggiunzione.Find(id);
            db.Aggiunzione.Remove(a);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}