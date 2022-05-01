using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using doAn_KTLT.Entities;
using System.IO;
using Newtonsoft.Json;


namespace doAn_KTLT.DAL
{
    public class LuuTruHoaDonNhap
    {
        public static bool Luu(List<HoaDonNhap> dsHoaDonNhap)
        {
            StreamWriter file = new StreamWriter("./hoadonnhap.json");
            string json = JsonConvert.SerializeObject(dsHoaDonNhap);
            file.Write(json);
            file.Close();
            return true;
        }
        public static List<HoaDonNhap> Doc()
        {
            List<HoaDonNhap> dsHoaDonNhap;
            StreamReader file = new StreamReader("./hoadonnhap.json");
            string json = file.ReadToEnd();
            file.Close();
            dsHoaDonNhap = JsonConvert.DeserializeObject<List<HoaDonNhap>>(json);
            return dsHoaDonNhap;
        }
        public static void luuHoaDonNhap(HoaDonNhap hoaDonNhap)
        {
            List<HoaDonNhap> dsHoaDonNhap = Doc();
            dsHoaDonNhap.Add(hoaDonNhap);
            Luu(dsHoaDonNhap);
        }
    }
}
