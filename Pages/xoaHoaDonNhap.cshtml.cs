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
    public class xoaHoaDonNhapModel : PageModel
    {
        public HoaDonNhap hoaDonNhap;
        public string ketQua;
        public bool kiemTra;
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }
        public void OnGet()
        {
            HoaDonNhap? hdn = XuLyHoaDonNhap.timHoaDonNhap(id);
            if(hdn != null)
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
            bool kq = XuLyHoaDonNhap.Xoa(id);
            if(kq == true)
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
