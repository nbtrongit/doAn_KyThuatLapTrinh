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
    public class themHoaDonBanModel : PageModel
    {
        public List<MatHang> dsMatHang;
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
        public string ketQua;
        public HoaDonBan hoaDonBan;
        public void OnGet()
        {
            dsMatHang = XuLyMatHang.timKiem(string.Empty);
            ketQua = string.Empty;
            for(int i = 0; i < dsMatHang.Count; i++)
            {
                if(XuLyHoaDonBan.tongBanTheoMatHang(dsMatHang[i].maHang) == XuLyHoaDonNhap.tongNhapTheoMatHang(dsMatHang[i].maHang))
                {
                    dsMatHang.Remove(dsMatHang[i]);
                }
            }
        }
        public void OnPost()
        {
            dsMatHang = XuLyMatHang.timKiem(string.Empty);
            for (int i = 0; i < dsMatHang.Count; i++)
            {
                if (XuLyHoaDonBan.tongBanTheoMatHang(dsMatHang[i].maHang) == XuLyHoaDonNhap.tongNhapTheoMatHang(dsMatHang[i].maHang))
                {
                    dsMatHang.Remove(dsMatHang[i]);
                }
            }
            hoaDonBan.maHoaDon = maHD;
            hoaDonBan.ngayHoaDon = XuLyDate.phanGiai(ngayHD);
            hoaDonBan.maHang = maMH;
            hoaDonBan.soLuong = soLuong;
            hoaDonBan.donGia = donGia;
            ketQua = $"Thêm: {XuLyHoaDonBan.themHoaDonBan(hoaDonBan)}";
        }
    }
}
