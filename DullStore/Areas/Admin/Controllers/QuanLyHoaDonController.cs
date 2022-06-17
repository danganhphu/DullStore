using DullStore.DAO;
using DullStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DullStore.Areas.Admin.Controllers
{
    public class QuanLyHoaDonController : Controller
    {
        private DullShopEntities db = new DullShopEntities();

        // GET: Admin/QuanLyHoaDon
        public ActionResult ListHoaDon()
        {
            return View(db.GioHang.ToList().OrderBy(x => x.ma));
        }

        public ActionResult Edit(int id)
        {
            GioHang hd = db.GioHang.Find(id);
            if (hd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                return View(hd);
            }
        }

        [HttpPost]
        public ActionResult Edit(GioHang ghcs)
        {
            if (ModelState.IsValid)
            {
                GioHang hd = db.GioHang.Find(ghcs.ma);
                hd.tinhtranggiaohang = "Đã giao hàng và khách hàng đã thanh toán đầy đủ";
                db.SaveChanges();
                return RedirectToAction("ListHoaDon");
            }
            else
            {
                return View(ghcs);
            }
        }

        public ActionResult Details(int id)
        {
            GioHang gh = db.GioHang.SingleOrDefault(x => x.ma == id);
            ChiTietGioHangDAO dao = new ChiTietGioHangDAO();
            IQueryable<ChiTietGioHang> listgh = dao.ChiTietGH(id);
            ViewData["GioHang"] = gh;
            return View(listgh);
        }

        public ActionResult DeleteCT(int? id)
        {
            ChiTietGioHang cthd = db.ChiTietGioHang.SingleOrDefault(x => x.magiohang == id);
            if (cthd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                db.ChiTietGioHang.Remove(cthd);
                db.SaveChanges();
            }
            return RedirectToAction("ListHoaDon", "QuanLyHoaDon");
        }

        public ActionResult DeleteHD(int? id)
        {
            GioHang gh = db.GioHang.SingleOrDefault(x => x.ma == id);
            if (gh == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                db.GioHang.Remove(gh);
                db.SaveChanges();
            }
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}