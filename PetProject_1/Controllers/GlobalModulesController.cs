using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetProject_1.Models;

namespace PetProject_1.Controllers
{
    public class GlobalModulesController : Controller
    {
        private PortletContext db = new PortletContext();

        // GET: GlobalModules
        public ActionResult Index()
        {
            return View(db.GlobalModules.Include(gm => gm.UsingUser));
        }

        // GET: GlobalModules/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlobalModule globalModule = db.GlobalModules.Find(id);
            if (globalModule == null)
            {
                return HttpNotFound();
            }
            return View(globalModule);
        }

        // GET: GlobalModules/Create
        [HttpGet]
        public ActionResult Create()
        {
            SelectList users = new SelectList(db.Users, "Id", "FullName");
            ViewBag.Users = users;
            return View();
        }

        // POST: GlobalModules/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Uid,Name,UsingUserId")] GlobalModule globalModule)
        {
            if (ModelState.IsValid)
            {

                db.GlobalModules.Add(globalModule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(globalModule);
        }

        // GET: GlobalModules/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlobalModule globalModule = db.GlobalModules.Find(id);
            if (globalModule == null)
            {
                return HttpNotFound();
            }
            SelectList users = new SelectList(db.Users, "Id", "FullName", globalModule.UsingUserId);
            ViewBag.Users = users;
            return View(globalModule);
        }

        // POST: GlobalModules/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Uid,Name,UsingUserId")] GlobalModule globalModule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(globalModule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(globalModule);
        }

        // GET: GlobalModules/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GlobalModule globalModule = db.GlobalModules.Find(id);
            if (globalModule == null)
            {
                return HttpNotFound();
            }
            return View(globalModule);
        }

        // POST: GlobalModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GlobalModule globalModule = db.GlobalModules.Find(id);
            db.GlobalModules.Remove(globalModule);
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
