using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HWWEB.Models;

namespace HWWEB.Controllers
{
    public class FirmsController : Controller
    {
        private HWEntities db = new HWEntities();
        public ActionResult Index()
        {
            return View(db.Firm.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firm firm = db.Firm.Find(id);
            if (firm == null)
            {
                return HttpNotFound();
            }
            return View(firm);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirmID,FirmName")] Firm firm)
        {
            if (ModelState.IsValid)
            {
                db.Firm.Add(firm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(firm);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firm firm = db.Firm.Find(id);
            if (firm == null)
            {
                return HttpNotFound();
            }
            return View(firm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirmID,FirmName")] Firm firm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(firm);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Firm firm = db.Firm.Find(id);
            if (firm == null)
            {
                return HttpNotFound();
            }
            return View(firm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Firm firm = db.Firm.Find(id);
            db.Firm.Remove(firm);
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
