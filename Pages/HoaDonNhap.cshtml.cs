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
    public class HoaDonNhapModel : PageModel
    {
        public List<HoaDonNhap> dsHoaDonNhap;
        [BindProperty]
        public string tuKhoa { get; set; }
        public void OnGet()
        {
            dsHoaDonNhap = XuLyHoaDonNhap.timKiem(tuKhoa);
        }
        public void OnPost()
        {
            dsHoaDonNhap = XuLyHoaDonNhap.timKiem(tuKhoa);
        }
    }
}
