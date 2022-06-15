using DullStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DullStore.Areas.Admin.Controllers
{
    public class QuanLyDanhMucController : Controller
    {
        private DullShopEntities db = new DullShopEntities();

        private void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            switch (type)
            {
                case "success":
                    TempData["AlertType"] = "alert-success";
                    break;

                case "warning":
                    TempData["AlertType"] = "alert-warning";
                    break;

                case "error":
                    TempData["AlertType"] = "alert-error";
                    break;

                default:
                    TempData["AlertType"] = "";
                    break;
            }
        }

        // GET: Admin/QuanLyDanhMuc
        public ActionResult Category()
        {
            return View(db.DanhMuc.ToList().OrderBy(x => x.ma));
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(DanhMuc dm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SetAlert("Thêm danh mục thành công", "success");
                    db.DanhMuc.Add(dm);
                    db.SaveChanges();
                    return RedirectToAction("Category");
                }
                else
                {
                    SetAlert("Thêm danh mục không thành công. Kiểm tra lại!", "warning");
                    return View(dm);
                }
            }
            catch
            {
                SetAlert("Lỗi thêm danh mục", "error");
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            DanhMuc dm = db.DanhMuc.SingleOrDefault(x => x.ma == id);
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
        public ActionResult Edit(DanhMuc dmcs)
        {
            if (ModelState.IsValid)
            {
                SetAlert("Chỉnh sửa danh mục thành công", "success");
                DanhMuc dm = db.DanhMuc.Find(dmcs.ma);

                dm.tendanhmuc = dmcs.tendanhmuc;

                db.SaveChanges();

                return RedirectToAction("Category");
            }
            else
            {
                SetAlert("Chỉnh sửa danh mục không thành công", "warning");
                return View(dmcs);
            }
        }

        public ActionResult Delete(int id)
        {
            SetAlert("Xóa danh mục thành công", "success");
            DanhMuc dm = db.DanhMuc.Find(id);
            db.DanhMuc.Remove(dm);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}