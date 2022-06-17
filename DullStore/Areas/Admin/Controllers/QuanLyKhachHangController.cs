using DullStore.DAO;
using DullStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DullStore.Areas.Admin.Controllers
{
    public class QuanLyKhachHangController : Controller
    {
        private DullShopEntities db = new DullShopEntities();
        private KhachHangDAO khachHangDAO = new KhachHangDAO();

        // GET: Admin/QuanLyKhachHang
        public ActionResult ListKhachHang()
        {
            IQueryable<KhachHang> ListKH = khachHangDAO.ListKH();
            return View(ListKH);
        }

        public ActionResult Edit(int id)
        {
            KhachHang dm = db.KhachHang.SingleOrDefault(x => x.ma == id);
            if (dm == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            else
            {
                return View(dm);
            }
        }

        [HttpPost]
        public ActionResult Edit(KhachHang khcs)
        {
            if (ModelState.IsValid)
            {
                KhachHang kh = db.KhachHang.Find(khcs.ma);

                kh.hoten = khcs.hoten;
                kh.email = khcs.email;
                kh.diachi = khcs.diachi;
                kh.sodienthoai = khcs.sodienthoai;
                db.SaveChanges();

                return RedirectToAction("ListKhachHang");
            }
            else
            {
                return View(khcs);
            }
        }

        public ActionResult DeleteKH(int id)
        {
            KhachHang kh = db.KhachHang.Find(id);
            db.KhachHang.Remove(kh);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}