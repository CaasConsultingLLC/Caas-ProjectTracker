using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Caas_ProjectTracker.Models;

namespace Caas_ProjectTracker.Controllers
{
    public class CompanyListsController : Controller
    {
        private CaasConsultingllcEntities db = new CaasConsultingllcEntities();

        // GET: CompanyLists
        public ActionResult Index(string id)
        {
            string searchString = id;
            var companyLists = from m in db.CompanyLists
                               select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                companyLists = companyLists.Where(s => s.CompanyName.Contains(searchString));
            }
            return View(db.CompanyLists.ToList());
        }

        // GET: CompanyLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyList companyList = db.CompanyLists.Find(id);
            if (companyList == null)
            {
                return HttpNotFound();
            }
            return View(companyList);
        }

        // GET: CompanyLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,CompanyName,CorporateAddress,City,State,Country,PostalCode,Phone,Website,Notes")] CompanyList companyList)
        {
            if (ModelState.IsValid)
            {
                db.CompanyLists.Add(companyList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyList);
        }

        // GET: CompanyLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyList companyList = db.CompanyLists.Find(id);
            if (companyList == null)
            {
                return HttpNotFound();
            }
            return View(companyList);
        }

        // POST: CompanyLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,CompanyName,CorporateAddress,City,State,Country,PostalCode,Phone,Website,Notes")] CompanyList companyList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyList);
        }

        // GET: CompanyLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyList companyList = db.CompanyLists.Find(id);
            if (companyList == null)
            {
                return HttpNotFound();
            }
            return View(companyList);
        }

        // POST: CompanyLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyList companyList = db.CompanyLists.Find(id);
            db.CompanyLists.Remove(companyList);
            db.SaveChanges();
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
