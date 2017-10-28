using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrandRapids23_EntityFramework.Models;

namespace GrandRapids23_EntityFramework.Controllers
{
    public class Entity_FrameworkController : Controller
    {
        private GC23Entities db = new GC23Entities();

        // GET: Entity_Framework
        public ActionResult Index()
        {
            return View(db.Entity_Frameworks.ToList());
        }

        // GET: Entity_Framework/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entity_Framework entity_Framework = db.Entity_Frameworks.Find(id);
            if (entity_Framework == null)
            {
                return HttpNotFound();
            }
            return View(entity_Framework);
        }

        // GET: Entity_Framework/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entity_Framework/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Quantity,Price")] Entity_Framework entity_Framework)
        {
            if (ModelState.IsValid)
            {
                db.Entity_Frameworks.Add(entity_Framework);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entity_Framework);
        }

        // GET: Entity_Framework/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entity_Framework entity_Framework = db.Entity_Frameworks.Find(id);
            if (entity_Framework == null)
            {
                return HttpNotFound();
            }
            return View(entity_Framework);
        }

        // POST: Entity_Framework/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Quantity,Price")] Entity_Framework entity_Framework)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entity_Framework).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entity_Framework);
        }

        // GET: Entity_Framework/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entity_Framework entity_Framework = db.Entity_Frameworks.Find(id);
            if (entity_Framework == null)
            {
                return HttpNotFound();
            }
            return View(entity_Framework);
        }

        // POST: Entity_Framework/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Entity_Framework entity_Framework = db.Entity_Frameworks.Find(id);
            db.Entity_Frameworks.Remove(entity_Framework);
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
