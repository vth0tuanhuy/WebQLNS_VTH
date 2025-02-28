﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQLNS_VTH.Models;

namespace WebQLNS_VTH.Controllers
{
    public class ChucVusController : Controller
    {
        private Model1 db = new Model1();

        // GET: ChucVus
        public ActionResult Index()
        {
            //Session["Msg"] = null;
            ViewBag.PBan = db.PhongBans.ToList();
            //ViewBag.PBan1 = db.PhongBans.ToList();
            ViewBag.maPhongBan = new SelectList(db.PhongBans, "maPhongBan", "tenPhongBan");
            var chucVus = db.ChucVus.Include(c => c.PhongBan);
            return View(chucVus.ToList());
        }

        // GET: ChucVus/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucVu chucVu = db.ChucVus.Find(id);
            if (chucVu == null)
            {
                return HttpNotFound();
            }
            return View(chucVu);
        }

        // GET: ChucVus/Create
        public ActionResult Create()
        {
            ViewBag.maPhongBan = new SelectList(db.PhongBans, "maPhongBan", "tenPhongBan");
            return View();
        }

        // POST: ChucVus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tenChucVu,maPhongBan")] ChucVu chucVu)
        {
            if (ModelState.IsValid)
            {
                var manageController = new ManageController();
                var maNV = manageController.tuSinhMa(db.ChucVus.Max(x=> x.maChucVu));
                Debug.WriteLine(maNV.ToString());
                chucVu.maChucVu = maNV.ToString();
                db.ChucVus.Add(chucVu);
                db.SaveChanges();
                Session["Msg"] = "Thêm mới phúc";
                return RedirectToAction("Index");
            }

            ViewBag.maPhongBan = new SelectList(db.PhongBans, "maPhongBan", "tenPhongBan", chucVu.maPhongBan);
            return View(chucVu);
        }

        // GET: ChucVus/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucVu chucVu = db.ChucVus.Find(id);
            if (chucVu == null)
            {
                return HttpNotFound();
            }
            ViewBag.maPhongBan = new SelectList(db.PhongBans, "maPhongBan", "tenPhongBan", chucVu.maPhongBan);
            return View(chucVu);
        }

        // POST: ChucVus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maChucVu,tenChucVu,maPhongBan")] ChucVu chucVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chucVu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maPhongBan = new SelectList(db.PhongBans, "maPhongBan", "tenPhongBan", chucVu.maPhongBan);
            return View(chucVu);
        }

        // GET: ChucVus/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChucVu chucVu = db.ChucVus.Find(id);
            if (chucVu == null)
            {
                return HttpNotFound();
            }
            return View(chucVu);
        }

        // POST: ChucVus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChucVu chucVu = db.ChucVus.Find(id);
            db.ChucVus.Remove(chucVu);
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
