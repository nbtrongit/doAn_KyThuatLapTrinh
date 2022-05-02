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
    public class themMatHangModel : PageModel
    {
        public List<HoaDonNhap> dsHoaDonNhap;
        public List<MatHang> dsMatHang;
        public List<string> dsLoaiHang;
        [BindProperty]
        public string maHang { get; set; }
        [BindProperty]
        public string tenMH { get; set; }
        [BindProperty]
        public string hanDung { get; set; }
        [BindProperty]
        public string congtySX { get; set; }
        [BindProperty]
        public string ngaySX { get; set; }
        [BindProperty]
        public string loaiHang { get; set; }
        public MatHang matHang;
        public string ketQua;
        public void OnGet()
        {
            dsHoaDonNhap = XuLyHoaDonNhap.timKiem(string.Empty);
            dsMatHang = XuLyMatHang.timKiem(string.Empty);
            dsLoaiHang = XuLyLoaiHang.timKiem(string.Empty);
            for(int i = 0; i < dsHoaDonNhap.Count; i++)
            {
                for(int j = 0; j < dsMatHang.Count; j++)
                {
                    if(dsHoaDonNhap[i].maHang == dsMatHang[j].maHang)
                    {
                        dsHoaDonNhap.RemoveAt(i);
                    }
                }
            }
            ketQua = string.Empty;
        }
        public void OnPost()
        {
            dsHoaDonNhap = XuLyHoaDonNhap.timKiem(string.Empty);
            dsMatHang = XuLyMatHang.timKiem(string.Empty);
            dsLoaiHang = XuLyLoaiHang.timKiem(string.Empty);
            for (int i = 0; i < dsHoaDonNhap.Count; i++)
            {
                for (int j = 0; j < dsMatHang.Count; j++)
                {
                    if (dsHoaDonNhap[i].maHang == dsMatHang[j].maHang)
                    {
                        dsHoaDonNhap.RemoveAt(i);
                    }
                }
            }
            matHang.maHang = maHang;
            matHang.tenHang = tenMH;
            matHang.hanDung = XuLyDate.phanGiai(hanDung);
            matHang.congTySanXuat = congtySX;
            matHang.ngaySanXuat = XuLyDate.phanGiai(ngaySX);
            foreach (HoaDonNhap hdn in dsHoaDonNhap)
            {
                if(hdn.maHang == matHang.maHang)
                {
                    matHang.donGia = hdn.donGia;
                }
            }
            matHang.loaiHang = loaiHang;
            ketQua = $"Thêm: {XuLyMatHang.themMatHang(matHang)}";
        }
    }
}
