using DullStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.DAO
{
    public class StyleDAO
    {
        private DullShopEntities db;

        public StyleDAO()
        {
            db = new DullShopEntities();
        }

        public IQueryable<Style> ListDanhMuc()
        {
            var res = (from st in db.Style select st);
            return res;
        }
    }
}