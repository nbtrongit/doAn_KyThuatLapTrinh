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
    public class HangHetHanModel : PageModel
    {
        public List<MatHang> dsMatHang;
        public void OnGet()
        {
            dsMatHang = XuLyMatHang.hangHetHan();
        }
    }
}
