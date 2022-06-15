using DullStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.DAO
{
    public class GioHangDAO
    {
        private DullShopEntities db;

        public GioHangDAO()
        {
            db = new DullShopEntities();
        }
    }
}