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
    public class BrokersController : Controller
    {
        private HWEntities db = new HWEntities();
        public ActionResult Index()
        {
            return View(db.Broker.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Broker broker = db.Broker.Find(id);
            if (broker == null)
            {
                return HttpNotFound();
            }
            return View(broker);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrokerID,FullName")] Broker broker)
        {
            if (ModelState.IsValid)
            {
                db.Broker.Add(broker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(broker);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Broker broker = db.Broker.Find(id);
            if (broker == null)
            {
                return HttpNotFound();
            }
            return View(broker);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrokerID,FullName")] Broker broker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(broker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(broker);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Broker broker = db.Broker.Find(id);
            if (broker == null)
            {
                return HttpNotFound();
            }
            return View(broker);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Broker broker = db.Broker.Find(id);
            db.Broker.Remove(broker);
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
