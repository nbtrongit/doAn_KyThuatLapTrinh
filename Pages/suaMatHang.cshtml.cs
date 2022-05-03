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
    public class suaMatHangModel : PageModel
    {
        public MatHang matHang;
        public List<string> dsLoaiHang;
        public string ketQua;
        public bool kiemTra;
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }
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
        public int donGia { get; set; }
        [BindProperty]
        public string loaiHang { get; set; }
        public void OnGet()
        {
            dsLoaiHang = XuLyLoaiHang.timKiem(string.Empty);
            MatHang? mh = XuLyMatHang.timMatHang(id);
            if (mh != null)
            {
                matHang = mh.Value;
            }
            else
            {
                ketQua = "Không tìm thấy mặt hàng";
            }
            kiemTra = (mh != null);
        }
        public void OnPost()
        {
            dsLoaiHang = XuLyLoaiHang.timKiem(string.Empty);
            matHang.maHang = maHang;
            matHang.tenHang = tenMH;
            matHang.hanDung = XuLyDate.phanGiai(hanDung);
            matHang.congTySanXuat = congtySX;
            matHang.ngaySanXuat = XuLyDate.phanGiai(ngaySX);
            matHang.donGia = donGia;
            matHang.loaiHang = loaiHang;
            bool kq = XuLyMatHang.Sua(id, matHang);
            if (kq == true)
            {
                Response.Redirect("/MatHang");
            }
            else
            {
                ketQua = "Xóa: False";
            }
        }
    }
}
