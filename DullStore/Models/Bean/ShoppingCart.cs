using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DullStore.Models.Bean
{
    public class ShoppingCart
    {
        public List<ItemCart> listItem = new List<ItemCart>();

        public void AddItem(int id, string name, int soluong, double gia, string linkanh)
        {
            bool check = false;
            foreach (var item in listItem)
            {
                if (item.id == id)
                {
                    check = true;
                    item.soluong += soluong;
                    break;
                }
            }
            if (!check)
            {
                ItemCart item = new ItemCart();
                item.id = id;
                item.name = name;
                item.linkanh = linkanh;
                item.soluong = soluong;
                item.gia = gia;
                listItem.Add(item);
            }
        }

        public void AddSoluong(int id, int soluong)
        {
            foreach (var item in listItem)
            {
                if (item.id == id)
                {
                    item.soluong += soluong;
                    break;
                }
            }
        }

        public void Delete(int id)
        {
            foreach (var item in listItem)
            {
                if (item.id == id)
                {
                    listItem.Remove(item);
                    break;
                }
            }
        }

        public void UpdateTang(int id)
        {
            foreach (var item in listItem)
            {
                if (item.id == id)
                {
                    item.soluong += 1;
                }
            }
        }

        public void UpdateGiam(int id)
        {
            foreach (var item in listItem)
            {
                if (item.id == id)
                {
                    item.soluong -= 1;
                    if (item.soluong == 0)
                    {
                        listItem.Remove(item);
                        break;
                    }
                }
            }
        }

        public double TongGiaTien()
        {
            double total = 0;
            foreach (var item in listItem)
            {
                total += item.TongGia();
            }

            return total;
        }

        public int TongSoLuong()
        {
            int total = 0;
            foreach (var item in listItem)
            {
                total += item.soluong;
            }
            return total;
        }
    }
}