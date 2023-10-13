using InForno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InForno.Controllers
{
    [Authorize(Roles ="Admin,User")]
    public class HomeController : Controller
    {
        private static ModelDBContext db = new ModelDBContext();
        public List<Aggiunzione> aggiunzioni = db.Aggiunzione.ToList();
        public List<SelectListItem> a
        {
            get
            {
                List<SelectListItem> aList = new List<SelectListItem>();
                foreach (Aggiunzione agg in aggiunzioni)
                {
                    SelectListItem item = new SelectListItem { Text = agg.Nome + "($" + agg.Prezzo +")", Value = agg.IdAggiunzione.ToString() };
                    aList.Add(item);
                }
                return aList;
            }
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ViewBag.Aggiunzioni = a;
            ViewBag.Carrello = Session["Carrello"];
            return View(db.Prodotto.ToList());
        }


        public ActionResult AddToCart(int IdProdotto, int IdAggiunzione, int Quantita)
        {
            Prodotto p = db.Prodotto.Find(IdProdotto);
            Aggiunzione a = db.Aggiunzione.Find(IdAggiunzione);
            Cart cartItem = new Cart(Quantita, p.Nome, p.Prezzo,a.Prezzo, IdProdotto, IdAggiunzione);
            List<Cart> carrello = Session["Carrello"] as List<Cart> ?? new List<Cart>();
            carrello.Add(cartItem);
            Session["Carrello"] = carrello;
            return RedirectToAction("Index");
        }

        public ActionResult Remove( int id)
        {
            List<Cart> carrello = Session["Carrello"] as List<Cart>;
            carrello.RemoveAt(id);
            Session["Carrello"] = carrello;
            return RedirectToAction("Index");
        }
    }
}
