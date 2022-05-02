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
    public class suaHoaDonNhapModel : PageModel
    {
        public HoaDonNhap hoaDonNhap;
        public string ketQua;
        public bool kiemTra;
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }
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
            HoaDonNhap? hdn = XuLyHoaDonNhap.timHoaDonNhap(id);
            if (hdn != null)
            {
                hoaDonNhap = hdn.Value;
            }
            else
            {
                ketQua = "Không tìm thấy hóa đơn nhập";
            }
            kiemTra = (hdn != null);
        }
        public void OnPost()
        {
            hoaDonNhap.maHoaDon = maHD;
            hoaDonNhap.ngayHoaDon = XuLyDate.phanGiai(ngayHD);
            hoaDonNhap.maHang = maMH;
            hoaDonNhap.soLuong = soLuong;
            hoaDonNhap.donGia = donGia;
            bool kq = XuLyHoaDonNhap.Sua(id, hoaDonNhap);
            if (kq == true)
            {
                Response.Redirect("/HoaDonNhap");
            }
            else
            {
                ketQua = "Xóa: False";
            }
        }
    }
}
