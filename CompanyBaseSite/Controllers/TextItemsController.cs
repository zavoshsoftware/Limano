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

namespace Felarise.Controllers
{
    public class TextItemsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        public ActionResult Index(string typename)
        {
            var textItems = db.TextItems.Include(t => t.TextItemType)
                .Where(t => t.TextItemType.TypeName == typename && t.IsDeleted == false).OrderByDescending(t => t.CreationDate);
          
            return View(textItems.ToList());
        }
          
        public ActionResult Create(string typename)
        {
            ViewBag.TextItemTypeId = typename;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TextItem textItem, string typename, HttpPostedFileBase fileupload)
        {
            if (ModelState.IsValid)
            {
                TextItemType textItemType = db.TextItemTypes.FirstOrDefault(c => c.TypeName == typename);

                #region Upload and resize image if needed
                string newFilenameUrl = string.Empty;
                if (fileupload != null)
                {
                    string filename = Path.GetFileName(fileupload.FileName);
                    string newFilename = Guid.NewGuid().ToString().Replace("-", string.Empty)
                                         + Path.GetExtension(filename);

                    newFilenameUrl = "/Uploads/text/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);
                    fileupload.SaveAs(physicalFilename);
                    textItem.ImageUrl = newFilenameUrl;
                }


                #endregion
                textItem.IsDeleted=false;
				textItem.CreationDate= DateTime.Now;
                textItem.TextItemTypeId = textItemType.Id;
                textItem.Id = Guid.NewGuid();
                db.TextItems.Add(textItem);
                db.SaveChanges();
                return RedirectToAction("Index",new { typename = typename });
            }

            ViewBag.TextItemTypeId = typename;
            return View(textItem);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextItem textItem = db.TextItems.Find(id);
            if (textItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.TextItemTypeId =   textItem.TextItemType.TypeName;
            return View(textItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TextItem textItem ,HttpPostedFileBase fileupload)
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

                    newFilenameUrl = "/Uploads/text/" + newFilename;
                    string physicalFilename = Server.MapPath(newFilenameUrl);
                    fileupload.SaveAs(physicalFilename);
                    textItem.ImageUrl = newFilenameUrl;
                }


                #endregion
                textItem.IsDeleted=false;
					textItem.LastModifiedDate=DateTime.Now;
                db.Entry(textItem).State = EntityState.Modified;
                db.SaveChanges();

                
                return RedirectToAction("Index",new { typename = GetTextTypeNameById(textItem.TextItemTypeId.Value)});
            }

            ViewBag.TextItemTypeId = textItem.TextItemType.TypeName;
            return View(textItem);
        }

        public string GetTextTypeNameById(Guid id)
        {
            var texttype = db.TextItemTypes.FirstOrDefault(c => c.Id == id);

            if (texttype != null)
                return texttype.TypeName;
            return string.Empty;
        }
        // GET: TextItems/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TextItem textItem = db.TextItems.Find(id);
            if (textItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.TextItemTypeId =   textItem.TextItemType.TypeName;
            return View(textItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TextItem textItem = db.TextItems.Find(id);
			textItem.IsDeleted=true;
			textItem.DeletionDate=DateTime.Now;
 
            db.SaveChanges();
            return RedirectToAction("Index", new { name = textItem.TextItemType.TypeName });
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
