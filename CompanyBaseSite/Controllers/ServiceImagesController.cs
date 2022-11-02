using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models;

namespace CompanyBaseSite.Controllers
{
    public class ServiceImagesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: ServiceImages
        public ActionResult Index(Guid id)
        {
            var serviceImages = db.ServiceImages.Include(s => s.Service).Where(s=>s.ServiceId==id&&s.IsDeleted==false).OrderByDescending(s=>s.CreationDate);
            return View(serviceImages.ToList());
        }
         
        public ActionResult Create(Guid id)
        {
            ViewBag.ServiceId = id;
            return View();
        }

        // POST: ServiceImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ServiceImage serviceImage, Guid id, HttpPostedFileBase fileupload)
        {
            if (ModelState.IsValid)
            {
                #region Upload and resize image if needed
                string newFilenameUrl = string.Empty;
                if (fileupload != null)
                {
                    string filename = Path.GetFileName(fileupload.FileName);
                    string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty)
                                         + Path.GetExtension(filename);

                    newFilenameUrl = "/Uploads/service/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);
                    fileupload.SaveAs(physicalFilename);
                    serviceImage.ImageUrl = newFilenameUrl;
                }
                #endregion
                serviceImage.IsDeleted=false;
				serviceImage.CreationDate= DateTime.Now;
                serviceImage.ServiceId = id;
                serviceImage.Id = Guid.NewGuid();
                db.ServiceImages.Add(serviceImage);
                db.SaveChanges();
                return RedirectToAction("Index",new {id=id});
            }

            ViewBag.ServiceId = id;
            return View(serviceImage);
        }

        // GET: ServiceImages/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceImage serviceImage = db.ServiceImages.Find(id);
            if (serviceImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceId = serviceImage.ServiceId;
            return View(serviceImage);
        }

        // POST: ServiceImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ServiceImage serviceImage, HttpPostedFileBase fileupload)
        {
            if (ModelState.IsValid)
            {
                #region Upload and resize image if needed
                string newFilenameUrl = string.Empty;
                if (fileupload != null)
                {
                    string filename = Path.GetFileName(fileupload.FileName);
                    string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty)
                                         + Path.GetExtension(filename);

                    newFilenameUrl = "/Uploads/service/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);
                    fileupload.SaveAs(physicalFilename);
                    serviceImage.ImageUrl = newFilenameUrl;
                }
                #endregion
                serviceImage.IsDeleted=false;
					serviceImage.LastModifiedDate=DateTime.Now;
                db.Entry(serviceImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index",new{id = serviceImage.ServiceId });
            }
            ViewBag.ServiceId =   serviceImage.ServiceId ;
            return View(serviceImage);
        }

        // GET: ServiceImages/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceImage serviceImage = db.ServiceImages.Find(id);
            if (serviceImage == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceId = serviceImage.ServiceId;

            return View(serviceImage);
        }

        // POST: ServiceImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ServiceImage serviceImage = db.ServiceImages.Find(id);
			serviceImage.IsDeleted=true;
			serviceImage.DeletionDate=DateTime.Now;
 
            db.SaveChanges();
            return RedirectToAction("Index", new { id = serviceImage.ServiceId });
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
