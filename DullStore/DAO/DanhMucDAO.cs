using DullStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.DAO
{
    public class DanhMucDAO
    {
        private DullShopEntities db;

        public DanhMucDAO()
        {
            db = new DullShopEntities();
        }

        public IQueryable<DanhMuc> ListDanhMuc()
        {
            var res = (from dm in db.DanhMuc select dm);
            return res;
        }
    }
}