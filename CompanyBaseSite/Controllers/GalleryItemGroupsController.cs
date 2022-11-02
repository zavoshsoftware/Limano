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
    public class GalleryItemGroupsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: GalleryItemGroups
        public ActionResult Index()
        {
            return View(db.GalleryItemGroups.Where(a=>a.IsDeleted==false).OrderByDescending(a=>a.CreationDate).ToList());
        }

        // GET: GalleryItemGroups/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryItemGroup galleryItemGroup = db.GalleryItemGroups.Find(id);
            if (galleryItemGroup == null)
            {
                return HttpNotFound();
            }
            return View(galleryItemGroup);
        }

        // GET: GalleryItemGroups/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GalleryItemGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,IsActive,CreationDate,LastModifiedDate,IsDeleted,DeletionDate,Description")] GalleryItemGroup galleryItemGroup)
        {
            if (ModelState.IsValid)
            {
				galleryItemGroup.IsDeleted=false;
				galleryItemGroup.CreationDate= DateTime.Now; 
					
                galleryItemGroup.Id = Guid.NewGuid();
                db.GalleryItemGroups.Add(galleryItemGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(galleryItemGroup);
        }

        // GET: GalleryItemGroups/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryItemGroup galleryItemGroup = db.GalleryItemGroups.Find(id);
            if (galleryItemGroup == null)
            {
                return HttpNotFound();
            }
            return View(galleryItemGroup);
        }

        // POST: GalleryItemGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,IsActive,CreationDate,LastModifiedDate,IsDeleted,DeletionDate,Description")] GalleryItemGroup galleryItemGroup)
        {
            if (ModelState.IsValid)
            {
				galleryItemGroup.IsDeleted=false;
					galleryItemGroup.LastModifiedDate=DateTime.Now;
                db.Entry(galleryItemGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(galleryItemGroup);
        }

        // GET: GalleryItemGroups/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GalleryItemGroup galleryItemGroup = db.GalleryItemGroups.Find(id);
            if (galleryItemGroup == null)
            {
                return HttpNotFound();
            }
            return View(galleryItemGroup);
        }

        // POST: GalleryItemGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            GalleryItemGroup galleryItemGroup = db.GalleryItemGroups.Find(id);
			galleryItemGroup.IsDeleted=true;
			galleryItemGroup.DeletionDate=DateTime.Now;
 
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
