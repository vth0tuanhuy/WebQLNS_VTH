using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQLNS_VTH.Models;

namespace WebQLNS_VTH.Controllers
{
    public class NghiPhepsController : Controller
    {
        private Model1 db = new Model1();

        // GET: NghiPheps
        public ActionResult Index()
        {
            var nghiPheps = db.NghiPheps.Include(n => n.NhanVien);
            return View(nghiPheps.ToList());
        }

        // GET: NghiPheps/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NghiPhep nghiPhep = db.NghiPheps.Find(id);
            if (nghiPhep == null)
            {
                return HttpNotFound();
            }
            return View(nghiPhep);
        }

        // GET: NghiPheps/Create
        public ActionResult Create()
        {
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen");
            return View();
        }

        // POST: NghiPheps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "maNghiPhep,maNV,tuNgay,denNgay")] NghiPhep nghiPhep)
        {
            if (ModelState.IsValid)
            {
                db.NghiPheps.Add(nghiPhep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", nghiPhep.maNV);
            return View(nghiPhep);
        }

        // GET: NghiPheps/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NghiPhep nghiPhep = db.NghiPheps.Find(id);
            if (nghiPhep == null)
            {
                return HttpNotFound();
            }
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", nghiPhep.maNV);
            return View(nghiPhep);
        }

        // POST: NghiPheps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maNghiPhep,maNV,tuNgay,denNgay")] NghiPhep nghiPhep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nghiPhep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maNV = new SelectList(db.NhanViens, "maNV", "hoTen", nghiPhep.maNV);
            return View(nghiPhep);
        }

        // GET: NghiPheps/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NghiPhep nghiPhep = db.NghiPheps.Find(id);
            if (nghiPhep == null)
            {
                return HttpNotFound();
            }
            return View(nghiPhep);
        }

        // POST: NghiPheps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NghiPhep nghiPhep = db.NghiPheps.Find(id);
            db.NghiPheps.Remove(nghiPhep);
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
