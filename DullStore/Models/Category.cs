using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.Models
{
    public class Category
    {
        public List<string> listdm { get; set; }

        public Category()
        {
            listdm = new List<string>();
            listdm.Add("SamSung");
            listdm.Add("Iphone");
            listdm.Add("Xiaomi");
            listdm.Add("Vivo");
            listdm.Add("Nokia");
            listdm.Add("Oppo");
        }
    }
}