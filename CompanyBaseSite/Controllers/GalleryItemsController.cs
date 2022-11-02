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
    public class GalleryItemsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: GalleryItems
        public ActionResult Index()
        {
            var galleryItems = db.GalleryItems.Include(g => g.GalleryItemGroup).Where(g=>g.IsDeleted==false).OrderByDescending(g=>g.CreationDate);
            return View(galleryItems.ToList());
        }

        // GET: GalleryItems/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryItem galleryItem = db.GalleryItems.Find(id);
            if (galleryItem == null)
            {
                return HttpNotFound();
            }
            return View(galleryItem);
        }

        // GET: GalleryItems/Create
        public ActionResult Create()
        {
            ViewBag.GalleryItemGroupId = new SelectList(db.GalleryItemGroups, "Id", "Title");
            return View();
        }

        // POST: GalleryItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GalleryItem galleryItem, HttpPostedFileBase fileupload)
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

                    newFilenameUrl = "/Uploads/GalleryItem/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);
                    fileupload.SaveAs(physicalFilename);
                    galleryItem.ImageUrl = newFilenameUrl;
                }


                #endregion
                galleryItem.IsDeleted=false;
				galleryItem.CreationDate= DateTime.Now; 
					
                galleryItem.Id = Guid.NewGuid();
                db.GalleryItems.Add(galleryItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GalleryItemGroupId = new SelectList(db.GalleryItemGroups, "Id", "Title", galleryItem.GalleryItemGroupId);
            return View(galleryItem);
        }

        // GET: GalleryItems/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryItem galleryItem = db.GalleryItems.Find(id);
            if (galleryItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.GalleryItemGroupId = new SelectList(db.GalleryItemGroups, "Id", "Title", galleryItem.GalleryItemGroupId);
            return View(galleryItem);
        }

        // POST: GalleryItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GalleryItem galleryItem, HttpPostedFileBase fileupload)
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

                    newFilenameUrl = "/Uploads/GalleryItem/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);
                    fileupload.SaveAs(physicalFilename);
                    galleryItem.ImageUrl = newFilenameUrl;
                }


                #endregion
                galleryItem.IsDeleted=false;
					galleryItem.LastModifiedDate=DateTime.Now;
                db.Entry(galleryItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GalleryItemGroupId = new SelectList(db.GalleryItemGroups, "Id", "Title", galleryItem.GalleryItemGroupId);
            return View(galleryItem);
        }

        // GET: GalleryItems/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryItem galleryItem = db.GalleryItems.Find(id);
            if (galleryItem == null)
            {
                return HttpNotFound();
            }
            return View(galleryItem);
        }

        // POST: GalleryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            GalleryItem galleryItem = db.GalleryItems.Find(id);
			galleryItem.IsDeleted=true;
			galleryItem.DeletionDate=DateTime.Now;
 
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
