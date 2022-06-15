using DullStore.DAO;
using DullStore.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DullStore.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        private DullShopEntities db = new DullShopEntities();
        public static SanPhamDAO sp = new SanPhamDAO();
        private IQueryable<SanPham> ListSanPham = sp.ListSP();

        public ActionResult SPTheoMuc(int madm)
        {
            SanPhamDAO sp = new SanPhamDAO();
            IQueryable<SanPham> ListSP = sp.ListSP(madm);
            return View(ListSP);
        }

        public ActionResult Index(int? trang)
        {
            //return View(ListSanPham);
            int sosptrentrang = 6;
            int stttrang = (trang ?? 1);
            return View(db.SanPham.ToList().OrderBy(x => x.ma).ToPagedList(stttrang, sosptrentrang));
        }

        public ActionResult KMProduct()
        {
            return View(ListSanPham);
        }

        public ActionResult BCProduct()
        {
            return View(ListSanPham);
        }

        public ActionResult ChitietSP(int id)
        {
            SanPham sptk = new SanPham();
            foreach (var item in ListSanPham)
            {
                if (item.ma == id) sptk = item;
            }
            ViewBag.spct = sptk;
            return View();
        }

        public ActionResult TimKiem(string tensp)
        {
            SanPhamDAO sp = new SanPhamDAO();
            ViewData["TimKiem"] = sp.ListSpTimkiem(tensp);
            return View();
        }
    }
}