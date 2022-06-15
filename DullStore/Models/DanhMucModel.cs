using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.Models
{
    public class DanhMucModel
    {
        public List<SanPhamModel> ListSamSung { get; set; }

        public List<SanPhamModel> ListIphone { get; set; }

        public List<SanPhamModel> ListXiaomi { get; set; }

        public List<SanPhamModel> ListVivo { get; set; }

        public List<SanPhamModel> ListNokia { get; set; }

        public List<SanPhamModel> ListOppo { get; set; }

        public List<SanPhamModel> D1 { get; set; }
        public List<SanPhamModel> D2 { get; set; }
        public List<SanPhamModel> D3 { get; set; }

        public DanhMucModel()
        {
        }
    }
}