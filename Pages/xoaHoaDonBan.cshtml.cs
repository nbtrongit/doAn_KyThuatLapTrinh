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
    public class xoaHoaDonBanModel : PageModel
    {
        public HoaDonBan hoaDonBan;
        public string ketQua;
        public bool kiemTra;
        [BindProperty(SupportsGet = true)]
        public string id1 { get; set; }
        [BindProperty(SupportsGet = true)]
        public string id2 { get; set; }
        public void OnGet()
        {
            HoaDonBan? hdb = XuLyHoaDonBan.timHoaDonBan(id1, id2);
            if (hdb != null)
            {
                hoaDonBan = hdb.Value;
            }
            else
            {
                ketQua = "Không tìm thấy hóa đơn bán";
            }
            kiemTra = (hdb != null);
        }
        public void OnPost()
        {
            bool kq = XuLyHoaDonBan.Xoa(id1, id2);
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
