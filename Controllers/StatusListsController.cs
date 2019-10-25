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
    public class StatusListsController : Controller
    {
        private CaasConsultingllcEntities db = new CaasConsultingllcEntities();

        // GET: StatusLists
        public ActionResult Index()
        {
            return View(db.StatusLists.ToList());
        }

        // GET: StatusLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusList statusList = db.StatusLists.Find(id);
            if (statusList == null)
            {
                return HttpNotFound();
            }
            return View(statusList);
        }

        // GET: StatusLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusID,StatusName")] StatusList statusList)
        {
            if (ModelState.IsValid)
            {
                db.StatusLists.Add(statusList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusList);
        }

        // GET: StatusLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusList statusList = db.StatusLists.Find(id);
            if (statusList == null)
            {
                return HttpNotFound();
            }
            return View(statusList);
        }

        // POST: StatusLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusID,StatusName")] StatusList statusList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusList);
        }

        // GET: StatusLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusList statusList = db.StatusLists.Find(id);
            if (statusList == null)
            {
                return HttpNotFound();
            }
            return View(statusList);
        }

        // POST: StatusLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusList statusList = db.StatusLists.Find(id);
            db.StatusLists.Remove(statusList);
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
