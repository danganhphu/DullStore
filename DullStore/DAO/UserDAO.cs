using DullStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.DAO
{
    public class UserDAO
    {
        private DullShopEntities db;

        public UserDAO()
        {
            db = new DullShopEntities();
        }

        public bool Login(string tk, string mk)
        {
            var res = db.User.Count(x => x.userName == tk && x.password == mk);
            if (res > 0)
                return true;
            else
                return false;
        }
    }
}