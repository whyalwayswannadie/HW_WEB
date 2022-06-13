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
    public class BrokerageCompaniesController : Controller
    {
        private HWEntities db = new HWEntities();

        public ActionResult Index()
        {
            return View(db.BrokerageCompany.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrokerageCompany brokerageCompany = db.BrokerageCompany.Find(id);
            if (brokerageCompany == null)
            {
                return HttpNotFound();
            }
            return View(brokerageCompany);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BrokerageCompanyID,CompanyName")] BrokerageCompany brokerageCompany)
        {
            if (ModelState.IsValid)
            {
                db.BrokerageCompany.Add(brokerageCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brokerageCompany);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrokerageCompany brokerageCompany = db.BrokerageCompany.Find(id);
            if (brokerageCompany == null)
            {
                return HttpNotFound();
            }
            return View(brokerageCompany);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BrokerageCompanyID,CompanyName")] BrokerageCompany brokerageCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brokerageCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brokerageCompany);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrokerageCompany brokerageCompany = db.BrokerageCompany.Find(id);
            if (brokerageCompany == null)
            {
                return HttpNotFound();
            }
            return View(brokerageCompany);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BrokerageCompany brokerageCompany = db.BrokerageCompany.Find(id);
            db.BrokerageCompany.Remove(brokerageCompany);
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
