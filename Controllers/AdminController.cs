using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using LuxuryMVC.Models;

namespace LuxuryMVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index([Bind(Include = "Id,Title,SubTitle,SubTitle2,DisplayOffers")] Home homeInput)
        {
            if (homeInput.Id > 0)
            {
                db.Entry(homeInput).State = EntityState.Modified;
                db.SaveChanges();
            }
            Home home = db.Homes.Find(1);
            var offers = db.Offers.ToList();
            home.Offers = offers;
            if (home == null)
            {
                return HttpNotFound();
            }
            return View(home);
        }

        // GET: Offers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = await db.Offers.FindAsync(id);
            var templates = db.Templates.ToList();
            offer.Templates = templates;
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // POST: Offers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Desc1,Desc2,Desc3,Desc4,Price,Interval,Link,Body,TemplateId")] Offer offer)
        {
            if (ModelState.IsValid)
            {
                Template template = await db.Templates.FindAsync(offer.TemplateId);
                string newBody = template.BodyText.ToString().Replace("{{Title}}", offer.Title)
                                                             .Replace("{{Dscr1}}", offer.Desc1)
                                                             .Replace("{{Dscr2}}", offer.Desc2)
                                                             .Replace("{{Dscr3}}", offer.Desc3)
                                                             .Replace("{{Dscr4}}", offer.Desc4)
                                                             .Replace("{{Price}}", offer.Price)
                                                             .Replace("{{Interval}}", offer.Interval)
                                                             .Replace("{{SignUp}}", offer.Link);
                offer.Body = newBody;
                db.Entry(offer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(offer);
        }
    }
}