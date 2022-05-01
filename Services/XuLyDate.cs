using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doAn_KTLT.Entities;

namespace doAn_KTLT.Services
{
    public class XuLyDate
    {
        public static Date phanGiai(string chuoiNgay)
        {
            Date handung;
            string[] chuoi = chuoiNgay.Split("/");
            handung.Ngay = int.Parse(chuoi[0]);
            handung.Thang = int.Parse(chuoi[1]);
            handung.Nam = int.Parse(chuoi[2]);
            return handung;
        }
    }
}
