using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Reparation.DAL;
using Reparation.Models;

namespace Reparation.Controllers
{
    public class WorkOrdersController : Controller
    {
        private OurDbContext db = new OurDbContext();

        // GET: WorkOrders
        public ActionResult Index(string searchString)
        {
            if (Session["UserId"] != null)
            {
                var workordersearch = from wo in db.workOrders
                                      select wo;
                if (!String.IsNullOrEmpty(searchString))
                {
                    workordersearch = workordersearch.Where(wo => wo.CustomerMobileNumber.Contains(searchString)
                                           || wo.WorkOrderId.Contains(searchString) || wo.CustomerName.Contains(searchString));

                    return View(workordersearch.ToList());
                    //}
                    //else
                    //{
                    //    ModelState.AddModelError("", "No records found.");
                    //}

                }

                return View(db.workOrders.ToList());
            }
            else
            {
                return RedirectToAction("Login", "UserAccounts");
            }

        }
        // GET: WorkOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrders workOrders = db.workOrders.Find(id);
            if (workOrders == null)
            {
                return HttpNotFound();
            }
            return View(workOrders);
        }

        // GET: WorkOrders/Create
        public ActionResult Create()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "UserAccounts");
            }
        }

        // POST: WorkOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,WorkOrderId,GoldSmithName,CustomerName,CustomerMobileNumber,CustomerEmail,JewelleryDescription1,JewelleryDescription2,JewelleryDescription3,WorkToBeDone,WorkToBeDone2,WorkToBeDone3,AgentName,ProductGivenOn,DateAcceptedOrRejected,sAcceptedRejectedStatus,AmountToBeCollected,sStatus,Comments")] WorkOrders workOrders)
        {
            if (ModelState.IsValid)
            {
                db.workOrders.Add(workOrders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workOrders);
        }

        // GET: WorkOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrders workOrders = db.workOrders.Find(id);
            if (workOrders == null)
            {
                return HttpNotFound();
            }
            return View(workOrders);
        }

        // POST: WorkOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WorkOrderId,GoldSmithName,CustomerName,CustomerMobileNumber,CustomerEmail,JewelleryDescription1,JewelleryDescription2,JewelleryDescription3,WorkToBeDone,WorkToBeDone2,WorkToBeDone3,AgentName,ProductGivenOn,DateAcceptedOrRejected,sAcceptedRejectedStatus,AmountToBeCollected,sStatus,Comments")] WorkOrders workOrders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workOrders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workOrders);
        }

        // GET: WorkOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkOrders workOrders = db.workOrders.Find(id);
            if (workOrders == null)
            {
                return HttpNotFound();
            }
            return View(workOrders);
        }

        // POST: WorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkOrders workOrders = db.workOrders.Find(id);
            db.workOrders.Remove(workOrders);
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
