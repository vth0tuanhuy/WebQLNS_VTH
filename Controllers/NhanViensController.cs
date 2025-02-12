using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Microsoft.Ajax.Utilities;
using WebQLNS_VTH.Models;

namespace WebQLNS_VTH.Controllers
{
    public class NhanViensController : Controller
    {
        private Model1 db = new Model1();
        //Controller manageC = new ManageController(); 
        // GET: NhanViens
        public ActionResult Index()
        {
            var nhanViens = db.NhanViens.Include(n => n.ChucVu);
            return View(nhanViens.ToList());
        }

        // GET: NhanViens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Create
        public ActionResult Create()
        {
            ViewBag.maChucVu = new SelectList(db.ChucVus, "maChucVu", "tenChucVu");
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hoTen,diaChi,sdt,cccd,mail,ngaySinh,ngayVaoCT,gioiTinh,trinhDo,maChucVu,anh")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                nhanVien.anh = "logoft.png";
                var f = Request.Files["FileName"];
                if (f != null && f.ContentLength > 0)
                {
                    var tenfile = System.IO.Path.GetFileName(f.FileName);
                    var duongdan = Path.Combine(Server.MapPath("~/Img"), tenfile);
                    f.SaveAs(duongdan);
                    nhanVien.anh = tenfile;
                }
                var manageController = new ManageController();
                var maNV = manageController.tuSinhMa(db.NhanViens.Max(x=>x.maNV));
                Debug.WriteLine(maNV.ToString());
                nhanVien.maNV = maNV.ToString();
                db.NhanViens.Add(nhanVien);
                db.SaveChanges();
                Session["Msg"] = "Thêm nhân viên thành công";
                return RedirectToAction("Index");
            }

            ViewBag.maChucVu = new SelectList(db.ChucVus, "maChucVu", "tenChucVu", nhanVien.maChucVu);
            return View(nhanVien);
        }

        // GET: NhanViens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.maChucVu = new SelectList(db.ChucVus, "maChucVu", "tenChucVu", nhanVien.maChucVu);
            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "maNV,hoTen,diaChi,sdt,cccd,mail,ngaySinh,ngayVaoCT,gioiTinh,trinhDo,maChucVu,anh")] NhanVien nhanVien)
        {
            
            if (ModelState.IsValid)
            {
                var d = db.NhanViens.AsNoTracking().SingleOrDefault(x => x.maNV == nhanVien.maNV);
                var f = Request.Files["FileName"];
                if (f != null && f.ContentLength > 0)
                {
                    var tenfile = System.IO.Path.GetFileName(f.FileName);
                    var duongdan = Path.Combine(Server.MapPath("~/Img"), tenfile);
                    f.SaveAs(duongdan);
                    nhanVien.anh = tenfile;
                }
                else
                {
                    nhanVien.anh = d.anh;
                }
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.maChucVu = new SelectList(db.ChucVus, "maChucVu", "tenChucVu", nhanVien.maChucVu);
            return View(nhanVien);
        }
        //[HttpPost]
        //public ActionResult Delete(string id)
        //{
        //    var nhanVien = db.NhanViens.Find(id);
        //    if (nhanVien != null)
        //    {
        //        db.NhanViens.Remove(nhanVien);
        //        db.SaveChanges();
        //        return Json(new { success = true });
        //    }
        //    return Json(new { success = false });
        //}
        //GET: NhanViens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
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
