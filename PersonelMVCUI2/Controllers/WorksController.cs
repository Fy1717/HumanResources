using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonelMVCUI2.Models.EntityFramework;

namespace PersonelMVCUI2.Controllers
{
    public class WorksController : Controller
    {
        private PersonelManagementEntities db = new PersonelManagementEntities();

        // GET: Works
        public ActionResult Index()
        {
            var works = db.Works.Include(w => w.Personel);
            return View(works.ToList());
        }

        // GET: Works/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Works works = db.Works.Find(id);
            if (works == null)
            {
                return HttpNotFound();
            }
            return View(works);
        }

        // GET: Works/Create
        public ActionResult Create()
        {
            ViewBag.PersonelId = new SelectList(db.Personel, "Id", "Ad");
            return View();
        }

        // POST: Works/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Kategori,PersonelId,TeslimTarihi,Durum,Aciklama")] Works works)
        {
            if (ModelState.IsValid)
            {
                db.Works.Add(works);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonelId = new SelectList(db.Personel, "Id", "Ad", works.PersonelId);
            return View(works);
        }

        // GET: Works/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Works works = db.Works.Find(id);
            if (works == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonelId = new SelectList(db.Personel, "Id", "Ad", works.PersonelId);
            return View(works);
        }

        // POST: Works/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Kategori,PersonelId,TeslimTarihi,Durum,Aciklama")] Works works)
        {
            if (ModelState.IsValid)
            {
                db.Entry(works).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonelId = new SelectList(db.Personel, "Id", "Ad", works.PersonelId);
            return View(works);
        }

        // GET: Works/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Works works = db.Works.Find(id);
            if (works == null)
            {
                return HttpNotFound();
            }
            return View(works);
        }

        // POST: Works/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Works works = db.Works.Find(id);
            db.Works.Remove(works);
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
