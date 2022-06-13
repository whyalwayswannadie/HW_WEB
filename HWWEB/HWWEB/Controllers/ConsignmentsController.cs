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
    public class ConsignmentsController : Controller
    {
        private HWEntities db = new HWEntities();
        public ActionResult Index()
        {
            var consignment = db.Consignment.Include(c => c.Broker).Include(c => c.BrokerageCompany).Include(c => c.Product);
            return View(consignment.ToList());
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consignment consignment = db.Consignment.Find(id);
            if (consignment == null)
            {
                return HttpNotFound();
            }
            return View(consignment);
        }
        public ActionResult Create()
        {
            ViewBag.BrokerID = new SelectList(db.Broker, "BrokerID", "FullName");
            ViewBag.BrokerageCompanyID = new SelectList(db.BrokerageCompany, "BrokerageCompanyID", "CompanyName");
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConsignmentID,BrokerID,BrokerageCompanyID,ProductID,QuantityOfUnits,DeliveryCondition,ShippingDate")] Consignment consignment)
        {
            if (ModelState.IsValid)
            {
                db.Consignment.Add(consignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrokerID = new SelectList(db.Broker, "BrokerID", "FullName", consignment.BrokerID);
            ViewBag.BrokerageCompanyID = new SelectList(db.BrokerageCompany, "BrokerageCompanyID", "CompanyName", consignment.BrokerageCompanyID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductName", consignment.ProductID);
            return View(consignment);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consignment consignment = db.Consignment.Find(id);
            if (consignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrokerID = new SelectList(db.Broker, "BrokerID", "FullName", consignment.BrokerID);
            ViewBag.BrokerageCompanyID = new SelectList(db.BrokerageCompany, "BrokerageCompanyID", "CompanyName", consignment.BrokerageCompanyID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductName", consignment.ProductID);
            return View(consignment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsignmentID,BrokerID,BrokerageCompanyID,ProductID,QuantityOfUnits,DeliveryCondition,ShippingDate")] Consignment consignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrokerID = new SelectList(db.Broker, "BrokerID", "FullName", consignment.BrokerID);
            ViewBag.BrokerageCompanyID = new SelectList(db.BrokerageCompany, "BrokerageCompanyID", "CompanyName", consignment.BrokerageCompanyID);
            ViewBag.ProductID = new SelectList(db.Product, "ProductID", "ProductName", consignment.ProductID);
            return View(consignment);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consignment consignment = db.Consignment.Find(id);
            if (consignment == null)
            {
                return HttpNotFound();
            }
            return View(consignment);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consignment consignment = db.Consignment.Find(id);
            db.Consignment.Remove(consignment);
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
