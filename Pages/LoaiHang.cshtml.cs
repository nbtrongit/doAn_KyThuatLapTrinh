using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doAn_KTLT.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace doAn_KTLT.Pages
{
    public class LoaiHangModel : PageModel
    {
        public List<string> dsLoaiHang;
        [BindProperty]
        public string tuKhoa { get; set; }
        [BindProperty]
        public string tuKhoaMoi { get; set; }
        [BindProperty]
        public string suKien { get; set; }
        public string ketQua;
        public void OnGet()
        {
            dsLoaiHang = XuLyLoaiHang.timKiem(tuKhoa);
            ketQua = string.Empty;
            suKien = string.Empty;
        }
        public void OnPost()
        {
            if (suKien == "Tìm Kiếm")
            {
                dsLoaiHang = XuLyLoaiHang.timKiem(tuKhoa);
            }
            else if (suKien == "Thêm")
            {
                ketQua = $"Thêm: {XuLyLoaiHang.themLoaiHang(tuKhoa)}";
                dsLoaiHang = XuLyLoaiHang.timKiem(string.Empty);
            }
            else if (suKien == "Sửa")
            {
                dsLoaiHang = XuLyLoaiHang.timKiem(string.Empty);
                foreach (string lh in dsLoaiHang)
                {
                    if (lh == tuKhoa)
                    {
                        suKien = "True";
                        break;
                    }
                }
                if (suKien != "True")
                {
                    ketQua = "Sửa: False";
                }
            }
            else if (suKien == "Thay Đổi")
            {
                ketQua = $"Sửa: {XuLyLoaiHang.suaLoaiHang(tuKhoa, tuKhoaMoi)}";
                dsLoaiHang = XuLyLoaiHang.timKiem(string.Empty);
            }
            else if (suKien == "Xóa")
            {
                ketQua = $"Xóa: {XuLyLoaiHang.xoaLoaiHang(tuKhoa)}";
                dsLoaiHang = XuLyLoaiHang.timKiem(string.Empty);
            }
        }
    }
}
