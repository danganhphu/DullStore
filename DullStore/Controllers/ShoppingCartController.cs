using DullStore.common;
using DullStore.Models;
using DullStore.Models.Bean;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DullStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart

        private DullShopEntities db = new DullShopEntities();

        public ActionResult AddGioHang(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
            }
            SanPham sp = db.SanPham.Find(id);
            cart.AddItem(sp.ma, sp.ten, 1, (double)sp.giaban, sp.linkanh);
            Session["cart"] = cart;
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult ListCart()
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            List<ItemCart> ls = new List<ItemCart>();
            if (cart != null)
            {
                ls = cart.listItem;
            }
            return View(ls);
        }

        public ActionResult UpdateTang(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            cart.UpdateTang(id);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult UpdateGiam(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            cart.UpdateGiam(id);
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult DeleteGioHang(int id)
        {
            ShoppingCart Cart = (ShoppingCart)Session["cart"];
            if (Cart != null)
                Cart.Delete(id);
            return Redirect(Request.UrlReferrer.ToString());
        }

        [HttpPost]
        public ActionResult DatHang(string ten, string email, string diachi, string sdt)
        {
            if (Session["cart"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            //them vao chi tiet gio hang
            KhachHang kh = new KhachHang();
            KhachHang test = db.KhachHang.SingleOrDefault(x => x.hoten == ten && x.email == email && x.diachi == diachi && x.sodienthoai == sdt);
            if (test != null)
            {
                kh.ma = test.ma;
                kh.hoten = test.hoten;
                kh.sodienthoai = test.sodienthoai;
                kh.email = test.email;
                kh.diachi = test.diachi;
            }
            else
            {
                kh.hoten = ten;
                kh.sodienthoai = sdt;
                kh.email = email;
                kh.diachi = diachi;
                db.KhachHang.Add(kh);
                db.SaveChanges();
            }
            ShoppingCart cart = (ShoppingCart)Session["cart"];
            GioHang gh = new GioHang();
            gh.ngaydathang = DateTime.Now;
            gh.ngaygiaohang = DateTime.Now;
            gh.tinhtranggiaohang = "Đang giao hàng";
            gh.makhachhang = kh.ma;
            db.GioHang.Add(gh);
            db.SaveChanges();

            foreach (ItemCart item in cart.listItem)
            {
                ChiTietGioHang ct = new ChiTietGioHang();
                ct.magiohang = gh.ma;
                ct.madt = item.id;
                ct.soluong = item.soluong;
                ct.dongia = item.TongGia().ToString();

                db.ChiTietGioHang.Add(ct);
                db.SaveChanges();
            }

            string contentAd = System.IO.File.ReadAllText(Server.MapPath("~/Content/template/neworder.html"));
            string contentKH = System.IO.File.ReadAllText(Server.MapPath("~/Content/template/khachhang.html"));

            contentAd = contentAd.Replace("{{CustomerName}}", ten);
            contentAd = contentAd.Replace("{{Phone}}", sdt);
            contentAd = contentAd.Replace("{{Email}}", email);
            contentAd = contentAd.Replace("{{Address}}", diachi);
            var tongGia = String.Format("{0:0,0 VNĐ}", cart.TongGiaTien());
            contentAd = contentAd.Replace("{{Total}}", tongGia);

            contentKH = contentKH.Replace("{{CustomerName}}", ten);
            contentKH = contentKH.Replace("{{Phone}}", sdt);
            contentKH = contentKH.Replace("{{Email}}", email);
            contentKH = contentKH.Replace("{{Address}}", diachi);
            var tongTien = String.Format("{0:0,0 VNĐ}", cart.TongGiaTien());
            contentKH = contentKH.Replace("{{Total}}", tongTien);

            var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();

            new MailHelper().SendMail("phu.da.61cntt@ntu.edu.vn", "DullStore - Đơn hàng mới", contentAd);
            new MailHelper().SendMail(email, "Đơn hàng từ DullStore", contentKH);
            ViewData["DonHang"] = gh;
            return View();
        }
    }
}