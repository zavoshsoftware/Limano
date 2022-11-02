using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace CompanyBaseSite.Controllers
{
    public class ServiceRequestsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            var serviceRequests = db.ServiceRequests.Include(s => s.Service).Where(s => s.IsDeleted == false).OrderByDescending(s => s.CreationDate);
            return View(serviceRequests.ToList());
        }

        // GET: ServiceRequests/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            if (serviceRequest == null)
            {
                return HttpNotFound();
            }
            return View(serviceRequest);
        }

        // GET: ServiceRequests/Create
        public ActionResult Create()
        {
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Title");
            return View();
        }

        // POST: ServiceRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,CellNumber,ServiceId,Body,IsActive,CreationDate,LastModifiedDate,IsDeleted,DeletionDate,Description")] ServiceRequest serviceRequest)
        {
            if (ModelState.IsValid)
            {
                serviceRequest.IsDeleted = false;
                serviceRequest.CreationDate = DateTime.Now;

                serviceRequest.Id = Guid.NewGuid();
                db.ServiceRequests.Add(serviceRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Title", serviceRequest.ServiceId);
            return View(serviceRequest);
        }

        // GET: ServiceRequests/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            if (serviceRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Title", serviceRequest.ServiceId);
            return View(serviceRequest);
        }

        // POST: ServiceRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,CellNumber,ServiceId,Body,IsActive,CreationDate,LastModifiedDate,IsDeleted,DeletionDate,Description")] ServiceRequest serviceRequest)
        {
            if (ModelState.IsValid)
            {
                serviceRequest.IsDeleted = false;
                serviceRequest.LastModifiedDate = DateTime.Now;
                db.Entry(serviceRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "Title", serviceRequest.ServiceId);
            return View(serviceRequest);
        }

        // GET: ServiceRequests/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            if (serviceRequest == null)
            {
                return HttpNotFound();
            }
            return View(serviceRequest);
        }

        // POST: ServiceRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ServiceRequest serviceRequest = db.ServiceRequests.Find(id);
            serviceRequest.IsDeleted = true;
            serviceRequest.DeletionDate = DateTime.Now;

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



        [AllowAnonymous]
        [HttpPost]
        public ActionResult SubmitRequest(string id, string name, string phone, string body)
        {
            try
            {


                ServiceRequest serviceRequest = new ServiceRequest();

                serviceRequest.FullName = name;
                serviceRequest.CellNumber = phone;
                serviceRequest.Body = body;
                serviceRequest.CreationDate = DateTime.Now;
                serviceRequest.IsDeleted = false;
                serviceRequest.Id = Guid.NewGuid();
                serviceRequest.IsActive = false;
                serviceRequest.ServiceId =new Guid(id);

                db.ServiceRequests.Add(serviceRequest);
                db.SaveChanges();
                return Json("true", JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json("false", JsonRequestBehavior.AllowGet);

            }
        }
    }
}
