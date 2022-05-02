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
    public class xoaMatHangModel : PageModel
    {
        public MatHang matHang;
        public string ketQua;
        public bool kiemTra;
        [BindProperty(SupportsGet = true)]
        public string id { get; set; }
        public void OnGet()
        {
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
            bool kq = XuLyMatHang.Xoa(id);
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
