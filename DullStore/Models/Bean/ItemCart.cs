﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.Models.Bean
{
    public class ItemCart
    {
        public int id { get; set; }
        public string name { get; set; }
        public int soluong { get; set; }
        public double gia { get; set; }
        public string linkanh { get; set; }

        public double TongGia()
        {
            return soluong * gia;
        }
    }
}