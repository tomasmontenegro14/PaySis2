using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationPaySis.Models;


namespace WebApplicationPaySis.Controllers
{
    public class TRANSACTIONSEntitiesController : Controller
    {
        private PaysisEntities db = new PaysisEntities();

        // GET: TRANSACTIONSEntities
        public ActionResult Index()
        {
            return View(db.TRANSACTIONSEntities.ToList().Take<TRANSACTIONSEntities>(20));
            
        }

        // GET: TRANSACTIONSEntities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACTIONSEntities tRANSACTIONSEntities = db.TRANSACTIONSEntities.Find(id);
            if (tRANSACTIONSEntities == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACTIONSEntities);
        }

        // GET: TRANSACTIONSEntities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TRANSACTIONSEntities/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TRANSACTION,STEP_TRANSACTION,TYPE_TRANSACTION,AMOUNT_TRANSACTION,NAMEORIG_TRANSACTION,OLDBALANCEORG_TRANSACTION,NEWBALANCEORIG_TRANSACTION,NAMEDEST_TRANSACTION,OLDBALANCEDEST_TRANSACTION,NEWBALANCEDEST_TRANSACTION,ISFRAUD_TRANSACTION,ISFLAGGEDFRAUD_TRANSACTION")] TRANSACTIONSEntities tRANSACTIONSEntities)
        {
            if (ModelState.IsValid)
            {
                db.TRANSACTIONSEntities.Add(tRANSACTIONSEntities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tRANSACTIONSEntities);
        }

        // GET: TRANSACTIONSEntities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACTIONSEntities tRANSACTIONSEntities = db.TRANSACTIONSEntities.Find(id);
            if (tRANSACTIONSEntities == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACTIONSEntities);
        }

        // POST: TRANSACTIONSEntities/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TRANSACTION,STEP_TRANSACTION,TYPE_TRANSACTION,AMOUNT_TRANSACTION,NAMEORIG_TRANSACTION,OLDBALANCEORG_TRANSACTION,NEWBALANCEORIG_TRANSACTION,NAMEDEST_TRANSACTION,OLDBALANCEDEST_TRANSACTION,NEWBALANCEDEST_TRANSACTION,ISFRAUD_TRANSACTION,ISFLAGGEDFRAUD_TRANSACTION")] TRANSACTIONSEntities tRANSACTIONSEntities)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRANSACTIONSEntities).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tRANSACTIONSEntities);
        }

        // GET: TRANSACTIONSEntities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACTIONSEntities tRANSACTIONSEntities = db.TRANSACTIONSEntities.Find(id);
            if (tRANSACTIONSEntities == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACTIONSEntities);
        }

        // POST: TRANSACTIONSEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRANSACTIONSEntities tRANSACTIONSEntities = db.TRANSACTIONSEntities.Find(id);
            db.TRANSACTIONSEntities.Remove(tRANSACTIONSEntities);
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
