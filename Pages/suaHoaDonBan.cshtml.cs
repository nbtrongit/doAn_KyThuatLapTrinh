using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using doAn_KTLT.Entities;
using doAn_KTLT.Services;

namespace doAn_KTLT.Pages
{
    public class suaHoaDonBanModel : PageModel
    {
        public HoaDonBan hoaDonBan;
        public string ketQua;
        public bool kiemTra;
        [BindProperty(SupportsGet = true)]
        public string id1 { get; set; }
        [BindProperty(SupportsGet = true)]
        public string id2 { get; set; }
        [BindProperty]
        public string maHD { get; set; }
        [BindProperty]
        public string ngayHD { get; set; }
        [BindProperty]
        public string maMH { get; set; }
        [BindProperty]
        public int soLuong { get; set; }
        [BindProperty]
        public int donGia { get; set; }
        public void OnGet()
        {
            HoaDonBan? hdb = XuLyHoaDonBan.timHoaDonBan(id1, id2);
            if (hdb != null)
            {
                hoaDonBan = hdb.Value;
            }
            else
            {
                ketQua = "Không tìm thấy hóa đơn nhập";
            }
            kiemTra = (hdb != null);
        }
        public void OnPost()
        {
            hoaDonBan.maHoaDon = maHD;
            hoaDonBan.ngayHoaDon = XuLyDate.phanGiai(ngayHD);
            hoaDonBan.maHang = maMH;
            hoaDonBan.soLuong = soLuong;
            hoaDonBan.donGia = donGia;
            bool kq = XuLyHoaDonBan.Sua(id1, id2, hoaDonBan);
            if (kq == true)
            {
                Response.Redirect("/HoaDonBan");
            }
            else
            {
                ketQua = "Xóa: False";
            }
        }
    }
}
