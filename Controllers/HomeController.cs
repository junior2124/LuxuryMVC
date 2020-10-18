using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LuxuryMVC.Models;

namespace LuxuryMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            Home home = db.Homes.Find(1);
            IEnumerable<Offer> offers = db.Offers.ToList();
            home.Offers = offers;

            if (home == null)
            {
                return HttpNotFound();
            }

            return View(home);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}