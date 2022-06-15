using DullStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.DAO
{
    public class KhachHangDAO
    {
        private DullShopEntities db;

        public KhachHangDAO()
        {
            db = new DullShopEntities();
        }

        public IQueryable<KhachHang> ListKH()
        {
            var res = (from kh in db.KhachHang select kh);
            return res;
        }
    }
}