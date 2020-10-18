using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LuxuryMVC.Models;

namespace LuxuryMVC.Controllers
{
    [Authorize]
    public class OffersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Offers
        public async Task<ActionResult> Index()
        {
            return View(await db.Offers.ToListAsync());
        }

        // GET: Offers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = await db.Offers.FindAsync(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // GET: Offers/Create
        public ActionResult Create()
        {
            var templates = db.Templates.ToList();
            var viewModel = new Offer
            {
                Templates = templates
            };

            return View(viewModel);
        }

        // POST: Offers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Desc1,Desc2,Desc3,Desc4,Price,Interval,Link,Body,TemplateId")] Offer offer)
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
                db.Offers.Add(offer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(offer);
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

        // GET: Offers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Offer offer = await db.Offers.FindAsync(id);
            if (offer == null)
            {
                return HttpNotFound();
            }
            return View(offer);
        }

        // POST: Offers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Offer offer = await db.Offers.FindAsync(id);
            db.Offers.Remove(offer);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
