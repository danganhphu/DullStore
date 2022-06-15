using DullStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.DAO
{
    public class ChiTietGioHangDAO
    {
        private DullShopEntities db;

        public ChiTietGioHangDAO()
        {
            db = new DullShopEntities();
        }

        public IQueryable<ChiTietGioHang> ChiTietGH(int mahd)
        {
            var res = (from sp in db.ChiTietGioHang where sp.magiohang == mahd select sp);
            return res;
        }
    }
}