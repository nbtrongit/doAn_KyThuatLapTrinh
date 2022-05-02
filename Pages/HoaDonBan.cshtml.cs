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
    public class HoaDonBanModel : PageModel
    {
        public List<HoaDonBan> dsHoaDonBan;
        [BindProperty]
        public string tuKhoa { get; set; }
        public void OnGet()
        {
            dsHoaDonBan = XuLyHoaDonBan.timKiem(tuKhoa);
        }
        public void OnPost()
        {
            dsHoaDonBan = XuLyHoaDonBan.timKiem(tuKhoa);
        }
    }
}
